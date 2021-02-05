using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.EFModels
{
    public class EFNotification
    {

        public int ID { get; set; }
        public EFNotificationLists NotificationLists { get; set; }
        public EFUser User { get; set; }
        public bool IsDisplay { get; set; }
    }
}
