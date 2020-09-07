using Microsoft.AspNetCore.Identity;
using Pae.web.Data.Entities;
using Pae.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Helpers
{

    public class UserHelper : IUserHelper
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Users> _signInManager;
        public UserHelper(
            UserManager<Users> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<Users> AddUser(AddUserModel view, string role)
        {
            var user = new Users
            {
                Address = view.Address,
                Document = view.Document,
                FirstName = view.FirstName,
                LastName = view.LastName,
                Movil = view.Movil,
                Activo = view.Activo,
                DateRegistro = DateTime.Now,
                Email = view.Username,
                
                UserName = view.Username
                
            };
            var result = await AddUserAsync(user, view.Password);
            if (result != IdentityResult.Success)
            {
                return null;

            }
            var newUser = await GetUserByEmailAsync(view.Username);
            await AddUserToRoleAsync(newUser, role);
            return newUser;
        }

        public async Task<IdentityResult> AddUserAsync(Users user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(Users user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<bool> DeleteUserAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null)
            {
                return true;
            }

            var response = await _userManager.DeleteAsync(user);
            return response.Succeeded;
        }


        public async Task<Users> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<bool> IsUserInRoleAsync(Users user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        //public async Task<SignInResult> LoginAsync(LoginViewModel model)
        //{
        //    return await _signInManager.PasswordSignInAsync(
        //        model.Username,
        //        model.Password,
        //        model.RememberMe,
        //        false);
        //}

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        //public Task<IdentityResult> UpdateEmployeAsync(Employee Employe)
        //{
        //    throw new System.NotImplementedException();
        //}

        public async Task<IdentityResult> UpdateUserAsync(Users user)
        {
            return await _userManager.UpdateAsync(user);
        }
        public async Task<SignInResult> ValidatePasswordAsync(Users user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(
                user,
                password,
                false);
        }

        public async Task<IdentityResult> ChangePasswordAsync(Users user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }
        public async Task<IdentityResult> ConfirmEmailAsync(Users user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(Users user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<Users> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

    }
}
