using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SuperShop.Data.Entities;
using SuperShop.Models;


namespace SuperShop.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManaager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private object _userManager;

        public UserHelper(UserManager<User> userManaager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManaager = userManaager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public Task<IdentityResult> AddUserAsync(User user, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> ChangePasswordAsync(
           User user,
           string oldPassword,
           string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName,
                });

            }
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManaager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<User> getUserByIdAsync(string userId)
        {
            retun await _userManager.FindByIsAsync(userId);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsyn(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public Task LogoutAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<SignInResult> ValidatePasswordAsync(User user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(
                user,
                password,
                false);
        }
    }
}
