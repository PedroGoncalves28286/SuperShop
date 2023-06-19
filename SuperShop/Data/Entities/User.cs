using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SuperShop.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get ; set; }  

        public string LastName { get ; set; }  

        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
