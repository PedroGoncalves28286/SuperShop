﻿using Microsoft.AspNetCore.Identity;

namespace SuperShop.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get ; set; }  

        public string LastName { get ; set; }  

        public string FullName => $"{FirstName} {LastName}";
    }
}
