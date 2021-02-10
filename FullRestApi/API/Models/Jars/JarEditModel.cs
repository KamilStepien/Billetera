using FullRESTAPI.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Jars
{
    public class JarEditModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime EndDate { get; set; }
        public int Aim { get; set; }
    }
}
