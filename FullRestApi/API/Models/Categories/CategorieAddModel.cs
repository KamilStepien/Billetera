using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Categories
{
    public class CategorieAddModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
