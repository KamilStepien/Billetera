using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Notifications
{
    public class DeactiveNotificationModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
    }
}
