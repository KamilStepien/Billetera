using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.EFModels
{
    public class EFJars
    {
        public int ID { get; set; }
        public EFUser User { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentMoney { get; set; }
        public int  Aim { get; set; }
        public JarState State { get; set; }
    }

    public enum JarState
    {
        Reached,
        NotReached,
        inProgress
    }

}
