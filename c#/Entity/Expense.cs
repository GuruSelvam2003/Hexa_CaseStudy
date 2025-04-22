using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial_Management
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Expense() { }

        public Expense(int userId, decimal amount, int categoryId, DateTime date, string description)
        {
            UserId = userId;
            Amount = amount;
            CategoryId = categoryId;
            Date = date;
            Description = description;
        }
    }
}
