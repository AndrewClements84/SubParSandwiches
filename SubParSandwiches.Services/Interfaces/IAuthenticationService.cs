using SubParSandwiches.Entities;
using System.Threading.Tasks;

namespace SubParSandwiches.Services.Interfaces
{
    public interface IAuthenticationService
    {
        bool CreateUser(User user, string Password);

        Task<bool> SignOut();

        User AuthenticateUser(string Username, string Password);

        User GetUser(string Username);
    }
}
