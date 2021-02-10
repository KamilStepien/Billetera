using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.ShoppingListElements
{
    public class ShopingListElementAddModel
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
    }
}
