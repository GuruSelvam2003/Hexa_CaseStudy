using Financial_Management.Dao;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using myexceptions;

namespace Financial_Management
{
    public class FinaceRepositoryimpl : IFinanceRepository
    {
        public bool CreateUser(User user)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    string query = "INSERT INTO Users(username, password, email) VALUES (@username, @password, @email)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@email", user.Email);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CreateUser: " + ex.Message);
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    string query = "DELETE FROM Users WHERE user_id = @userID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@userID", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new UserNotFoundException($"User ID {userId} not found.");
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteUser Error: " + ex.Message);
                return false;
            }
        }

        public bool CreateExpense(Expense expense)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    string query = "INSERT INTO Expenses (user_id, amount, category_id, date, description) VALUES (@userId, @amount, @categoryId, @date, @description)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@userId", expense.UserId);
                    cmd.Parameters.AddWithValue("@amount", expense.Amount);
                    cmd.Parameters.AddWithValue("@categoryId", expense.CategoryId);
                    cmd.Parameters.AddWithValue("@date", expense.Date);
                    cmd.Parameters.AddWithValue("@description", expense.Description);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreateExpense Error: " + ex.Message);
                return false;
            }
        }

        public bool DeleteExpense(int expenseId)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    string query = "DELETE FROM Expenses WHERE expense_id = @expenseId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@expenseId", expenseId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new ExpenseNotFoundException($"Expense ID {expenseId} not found.");
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteExpense Error: " + ex.Message);
                return false;
            }
        }

        public List<Expense> GetAllExpenses(int userId)
        {
            List<Expense> expenses = new List<Expense>();
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    string query = "SELECT * FROM Expenses WHERE user_id = @userId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Expense exp = new Expense
                        {
                            ExpenseId = (int)reader["expense_id"],
                            UserId = (int)reader["user_id"],
                            Amount = (decimal)reader["amount"],
                            CategoryId = (int)reader["category_id"],
                            Date = (DateTime)reader["date"],
                            Description = reader["description"].ToString()
                        };
                        expenses.Add(exp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAllExpenses Error: " + ex.Message);
            }

            return expenses;
        }

        public bool UpdateExpense(int userId, Expense expense)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    string query = "UPDATE Expenses SET amount = @amount, category_id = @categoryId, date = @date, description = @description WHERE expense_id = @expenseId AND user_id = @userId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@amount", expense.Amount);
                    cmd.Parameters.AddWithValue("@categoryId", expense.CategoryId);
                    cmd.Parameters.AddWithValue("@date", expense.Date);
                    cmd.Parameters.AddWithValue("@description", expense.Description);
                    cmd.Parameters.AddWithValue("@expenseId", expense.ExpenseId);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("Expense not found for update.");
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateExpense Error: " + ex.Message);
                return false;
            }
        }
    }
}
