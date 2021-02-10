using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Jars
{
    public class JarAddModel
    {
            public int UserId { get; set; }
            public string Name { get; set; }
            public DateTime EndDate { get; set; }
            public int Aim { get; set; }
        
    }
}
