using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FullRESTAPI.Models.EFModels
{
    public class EFUser
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarLink { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
