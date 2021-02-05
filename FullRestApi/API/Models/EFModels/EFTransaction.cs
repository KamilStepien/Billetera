using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.EFModels
{
    public class EFTransaction
    {
        public int ID{ get; set; }
        public EFUser User { get; set; }
        public EFCategorie Categorie { get; set; }
        public string Titl { get; set; }
        public DateTime CreateDate { get; set; }
        public int Amount { get; set; }
        public bool IsExpense { get; set; }
    }
}
