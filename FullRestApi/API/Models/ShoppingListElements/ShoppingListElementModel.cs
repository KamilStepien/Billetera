using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.ShoppingListElements
{
    public class ShoppingListElementModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
    }
}
