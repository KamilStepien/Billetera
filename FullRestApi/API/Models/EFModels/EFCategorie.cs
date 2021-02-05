using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.EFModels
{
    public class EFCategorie
    {
        public int ID { get; set; }
        public EFUser User { get; set; }
        public EFCategoriesLists CategoriesLists { get; set; }
    }
}
