using Microsoft.AspNetCore.Identity;
using Pae.web.Data.Entities;
using Pae.web.Models;
using System.Threading.Tasks;

namespace Pae.web.Helpers
{
    public interface IUserHelper
    {
        Task<Users> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(Users user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(Users user, string roleName);

        Task<bool> IsUserInRoleAsync(Users user, string roleName);
        //Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
        Task<bool> DeleteUserAsync(string email);
        Task<IdentityResult> UpdateUserAsync(Users user);
        //Task<IdentityResult> UpdateEmployeAsync(Employee Employe);
        Task<SignInResult> ValidatePasswordAsync(Users user, string password);
        Task<Users> AddUser(AddUserModel view, string role);
        Task<IdentityResult> ChangePasswordAsync(Users user, string oldPassword, string newPassword);

        Task<string> GenerateEmailConfirmationTokenAsync(Users user);

        Task<IdentityResult> ConfirmEmailAsync(Users user, string token);

        Task<Users> GetUserByIdAsync(string userId);
    }
}