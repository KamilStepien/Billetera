using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Transactions
{
    public class TransactionChartData
    {
        public DateTime Date { get; set; }
        public int AmountIncome { get; set; }
        public int AmountExpense { get; set; }
    }
}
