using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;



namespace SuperShop.Models
{
    
    
        public class RecoverPasswordViewModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }
    
}
