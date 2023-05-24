using Microsoft.AspNetCore.Identity;
using SuperShop.Data.Entities;
using System.Threading.Tasks;

namespace SuperShop.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManaager;

        public UserHelper(UserManager<User> userManaager)
        {
            _userManaager = userManaager;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManaager.CreateAsync(user, password);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManaager.FindByEmailAsync(email);
        }
    }
}
