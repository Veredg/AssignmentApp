using System.Threading.Tasks;
using AssignmenApp.API.Entities;
using AssignmenApp.API.Models;


namespace AssignmenApp.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register (User user);
        Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
 
    }
}
