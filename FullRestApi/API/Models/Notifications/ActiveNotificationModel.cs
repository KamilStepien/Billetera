﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Notifications
{
    public class ActiveNotificationModel
    {
        [Required]
        public int NotificationListId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
