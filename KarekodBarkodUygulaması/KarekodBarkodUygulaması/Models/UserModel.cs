using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarekodBarkodUygulaması.Models
{
    public class UserModel : IdentityUser
    {
        public UserModel(string userName) : base(userName)
        {
        }
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public string UserAdres { get; set; }
    }
}
