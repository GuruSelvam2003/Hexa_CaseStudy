using myexceptions;
using NUnit.Framework;
namespace Financial_Management.nUnitTests
{
    public class FinanceRepositoryTests
    {
        private FinaceRepositoryimpl repo;

        [SetUp]
        public void Setup()
        {
            repo = new FinaceRepositoryimpl();
        }

        [Test]
        public void CreateUser_ShouldReturnTrue_WhenValidUser()
        {
            var user = new User
            {
                Username = "nunituser",
                Password = "nunitpass",
                Email = "nunit@example.com"
            };

            bool result = repo.CreateUser(user);

            Assert.IsTrue(result, "User should be created successfully.");
        }

        [Test]
        public void CreateExpense_ShouldReturnTrue_WhenValidExpense()
        {
            var expense = new Expense
            {
                UserId = 1, 
                Amount = 1000,
                CategoryId = 1,
                Date = DateTime.Now,
                Description = "NUnit Test Expense"
            };

            bool result = repo.CreateExpense(expense);

            Assert.IsTrue(result, "Expense should be created successfully.");
        }

        [Test]
        public void GetAllExpenses_ShouldReturnList_WhenUserHasExpenses()
        {
            int userId = 1;
            var expenses = repo.GetAllExpenses(userId);

            Assert.IsNotNull(expenses);
        }

        [Test]
        public void DeleteUser_ShouldThrow_UserNotFoundException_WhenUserIdInvalid()
        {
            int UserId = 245;

            var ex = Assert.Throws<UserNotFoundException>(() => repo.DeleteUser(UserId));

            Assert.That(ex.Message, Is.EqualTo("User ID not found."));
        }

        [Test]
        public void DeleteExpense_ShouldThrow_ExpenseNotFoundException_WhenExpenseIdInvalid()
        {
            int ExpenseId = 100;

            var ex = Assert.Throws<ExpenseNotFoundException>(() => repo.DeleteExpense(ExpenseId));

            Assert.That(ex.Message, Is.EqualTo("Expense ID not found."));
        }
    }
}