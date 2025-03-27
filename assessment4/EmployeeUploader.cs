using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace assessment4
{
    public class EmployeeUploader
    {

        static string connectionString = "Server=E2770C24AB4B5C5\\SQLEXPRESS;Database=YOUR_DATABASE;Integrated Security=True;";

        static void Main()
        {
            InsertEmployee(103, "Charlie", "789 Street, City", 35000, 987654, 1);
            RetrieveEmployees();
            UpdateEmployeeSalary(103, 40000);
            DeleteEmployee(102);
            CalculatePF(103);
        }

        // Insert Employee
        static void InsertEmployee(int emp_id, string emp_name, string emp_address, decimal emp_salary, int emp_contact, int dept_id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Employee VALUES (@emp_id, @emp_name, @emp_address, @emp_salary, @emp_contact, @dept_id)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@emp_id", emp_id);
                    cmd.Parameters.AddWithValue("@emp_name", emp_name);
                    cmd.Parameters.AddWithValue("@emp_address", emp_address);
                    cmd.Parameters.AddWithValue("@emp_salary", emp_salary);
                    cmd.Parameters.AddWithValue("@emp-contact", emp_contact);
                    cmd.Parameters.AddWithValue("@dept_id", dept_id);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Employee {emp_name} inserted successfully.");
                }
            }
        }

        // Retrieve All Employees
        static void RetrieveEmployees()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Employee";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["emp_id"]}, Name: {reader["emp_name"]}, Salary: {reader["emp_salary"]}");
                    }
                }
            }
        }

        // Update Employee Salary
        static void UpdateEmployeeSalary(int emp_id, decimal newSalary)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Employee SET emp_salary = @emp_salary WHERE emp_id = @emp_id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@emp_salary", newSalary);
                    cmd.Parameters.AddWithValue("@emp_id", emp_id);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Employee {emp_id} salary updated to {newSalary}.");
                }
            }
        }

        // Delete Employee
        static void DeleteEmployee(int emp_id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Employee WHERE emp_id = @emp_id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@emp_id", emp_id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Employee {emp_id} deleted.");
                }
            }
        }

        // Calculate PF using Stored Procedure
        static void CalculatePF(int emp_id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string spQuery = "EXEC Calculate_PF @emp_id, @pfAmount OUTPUT";

                using (SqlCommand cmd = new SqlCommand(spQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@emp_id", emp_id);
                    SqlParameter outputParam = new SqlParameter("@pfAmount", SqlDbType.Decimal)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine($"Employee PF amount: {outputParam.Value}");
                }
            }
        }
    }
}



