using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial_Management.Dao
{
    public interface IFinanceRepository
    {
        bool CreateUser(User user);
        bool DeleteUser(int userId);
        bool CreateExpense(Expense expense);
        bool DeleteExpense(int expenseId);
        List<Expense> GetAllExpenses(int userId);
        bool UpdateExpense(int userId, Expense expense);
    }
}
