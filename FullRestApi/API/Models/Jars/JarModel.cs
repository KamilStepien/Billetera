using FullRESTAPI.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Jars
{
    public class JarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentMoney { get; set; }
        public int Aim { get; set; }
        public int ProcentFill { get; set; }
        public JarState State { get; set; }
    }
}
