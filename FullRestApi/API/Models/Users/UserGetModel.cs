using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Users
{
    public class UserGetModel
    {
        [Required]
        public int UserID { get; set; }
    }
}
