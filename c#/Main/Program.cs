using Financial_Management;

FinaceRepositoryimpl repo = new FinaceRepositoryimpl();

while (true)
{
    Console.WriteLine("\nFinance Management System");
    Console.WriteLine("1. Add User");
    Console.WriteLine("2. Add Expense");
    Console.WriteLine("3. Delete User");
    Console.WriteLine("4. Delete Expense");
    Console.WriteLine("5. Update Expense");
    Console.WriteLine("6. View All Expenses");
    Console.WriteLine("7. Exit");
    Console.Write("Choose an option: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            try
            {
                User user = new User();
                Console.Write("Enter username: ");
                user.Username = Console.ReadLine();
                Console.Write("Enter password: ");
                user.Password = Console.ReadLine();
                Console.Write("Enter email: ");
                user.Email = Console.ReadLine();

                bool userCreated = repo.CreateUser(user);
                Console.WriteLine(userCreated ? "User added successfully!" : "Failed to add user.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            break;

        case 2:
            try
            {
                Expense exp = new Expense();
                Console.Write("Enter User ID: ");
                exp.UserId = int.Parse(Console.ReadLine());
                Console.Write("Enter Amount: ");
                exp.Amount = decimal.Parse(Console.ReadLine());
                Console.Write("Enter Category ID: ");
                exp.CategoryId = int.Parse(Console.ReadLine());
                Console.Write("Enter Date (yyyy-MM-dd): ");
                exp.Date = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Description: ");
                exp.Description = Console.ReadLine();

                bool expCreated = repo.CreateExpense(exp);
                Console.WriteLine(expCreated ? "Expense added successfully!" : "Failed to add expense.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            break;

        case 3:
            try
            {
                Console.Write("Enter User ID to delete: ");
                int userIdToDelete = int.Parse(Console.ReadLine());
                bool userDeleted = repo.DeleteUser(userIdToDelete);
                Console.WriteLine(userDeleted ? "User deleted." : "Failed to delete user.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            break;

        case 4:
            try
            {
                Console.Write("Enter Expense ID to delete: ");
                int expIdToDelete = int.Parse(Console.ReadLine());
                bool expDeleted = repo.DeleteExpense(expIdToDelete);
                Console.WriteLine(expDeleted ? "Expense deleted." : "Failed to delete expense.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            break;

        case 5:
            try
            {
                Expense updatedExpense = new Expense();
                Console.Write("Enter your User ID: ");
                int uid = int.Parse(Console.ReadLine());
                Console.Write("Enter Expense ID to update: ");
                updatedExpense.ExpenseId = int.Parse(Console.ReadLine());
                Console.Write("Enter New Amount: ");
                updatedExpense.Amount = decimal.Parse(Console.ReadLine());
                Console.Write("Enter New Category ID: ");
                updatedExpense.CategoryId = int.Parse(Console.ReadLine());
                Console.Write("Enter New Date (yyyy-MM-dd): ");
                updatedExpense.Date = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter New Description: ");
                updatedExpense.Description = Console.ReadLine();

                bool expUpdated = repo.UpdateExpense(uid, updatedExpense);
                Console.WriteLine(expUpdated ? "Expense updated." : "Update failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            break;

        case 6:
            try
            {
                Console.Write("Enter User ID to view expenses: ");
                int viewUid = int.Parse(Console.ReadLine());
                List<Expense> expenses = repo.GetAllExpenses(viewUid);

                if (expenses.Count == 0)
                {
                    Console.WriteLine("No expenses found for this user.");
                }
                else
                {
                    foreach (Expense e in expenses)
                    {
                        Console.WriteLine($"ID: {e.ExpenseId}, Amount: {e.Amount}, Category: {e.CategoryId}, Date: {e.Date.ToShortDateString()}, Desc: {e.Description}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            break;

        case 7:
            Console.WriteLine("Exiting program.");
            return;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}
