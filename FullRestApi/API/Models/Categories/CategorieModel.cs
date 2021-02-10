using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Categories
{
    public class CategorieModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
      
    }
}
