using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.ShoppingListElements
{
    public class ShoppingElementListDeleteModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
    }
}
