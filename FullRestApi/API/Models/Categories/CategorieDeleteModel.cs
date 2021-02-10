﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Categories
{
    public class CategorieDeleteModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}

