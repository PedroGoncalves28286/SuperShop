using Microsoft.AspNetCore.Identity;
using SuperShop.Data.Entities;
using SuperShop.Models;
using System.Threading.Tasks;

namespace SuperShop.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManaager;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(UserManager<User> userManaager,SignInManager <User> signInManager)
        {
            _userManaager = userManaager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManaager.CreateAsync(user, password);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManaager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> LoginAsyn(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
