﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Models.Transactions
{
    public class TransactionEditModel
    {
        public int Id { get; set; }
        public int  CategorieId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int Amount { get; set; }
        public bool IsExpense { get; set; }
    }
}
