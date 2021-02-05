using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.EFModels
{
    public class EFShoppingElement
    {
        public int ID { get; set; }
        public EFUser User { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
    }
}
