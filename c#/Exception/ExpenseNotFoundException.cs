using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myexceptions
{
    public class ExpenseNotFoundException : Exception
    {
        public ExpenseNotFoundException() : base("Expense ID not found in the database.") { }

        public ExpenseNotFoundException(string message) : base(message) { }
    }
}
