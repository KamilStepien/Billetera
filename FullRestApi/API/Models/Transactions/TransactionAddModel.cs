using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Transactions
{
    public class TransactionAddModel
    {
        public int CategorieID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int Amount { get; set; }
        public bool IsExpense { get; set; }
    }
}
