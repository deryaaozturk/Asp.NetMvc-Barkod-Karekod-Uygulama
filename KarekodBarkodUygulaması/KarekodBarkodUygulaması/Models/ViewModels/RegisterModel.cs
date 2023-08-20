using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KarekodBarkodUygulaması.Models.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
        [Required]
        public string PasswordConfirm { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string TelefonNumarasi { get; set; }
        [Required]
        public string Adres { get; set; }
    }
}
