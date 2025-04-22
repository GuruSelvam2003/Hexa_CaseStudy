using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial_Management
{
    public class ExpenseCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        public ExpenseCategory(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
