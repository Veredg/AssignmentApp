using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AssignmenApp.API.Data;
using AssignmenApp.API.Entities;
using AssignmenApp.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _repo = repo;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userforRegisterDto)
        {
           
            userforRegisterDto.UserName = userforRegisterDto.UserName.ToLower();

            if (await _repo.UserExists(userforRegisterDto.UserName))
               return BadRequest("username already exists");

            var userToCreate = _mapper.Map<User>(userforRegisterDto);

            var createdUser = await _repo.Register(userToCreate);

            var userToReturn =  _mapper.Map<UserForRegisterDto>(createdUser);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userforLoginDto)
        {
            var userFromRepo = await _repo.Login(userforLoginDto.UserName.ToLower(), userforLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
              new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
              new Claim(ClaimTypes.Name, userFromRepo.UserName),
              new Claim(ClaimTypes.Email, userFromRepo.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
            (_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires= DateTime.Now.AddHours(24),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user = _mapper.Map<UserForRegisterDto>(userFromRepo);

            return Ok( tokenHandler.WriteToken(token));
        }
 
    }
}