using System;
using System.Threading.Tasks;
using AssignmenApp.API.Entities;
using AssignmenApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmenApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {

     private readonly DataContext _context;
     public AuthRepository(DataContext context)
            
    {
         _context = context;

    }
     public async Task<User> Register(User user)
    {

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }
         public async Task<User> Login(string username, string password)
    {
        var user = await _context.Users.Include(p=> p.Email).FirstOrDefaultAsync( x => x.UserName == username);

        if (user == null)
        return  null;
       
        return user;
    }
       public async Task<bool> UserExists(string username)
    {
        if (await _context.Users.AnyAsync(x => x.UserName == username))
        return true;

        return false;
    }
    }
}