using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Users
{
    public class UserEditModel
    {
        public int Id { get; set; }
        public string ActuallPassword { get; set; }
        public string NewPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarLink { get; set; }
    }
}
