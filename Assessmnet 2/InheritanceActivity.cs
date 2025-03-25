using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessmnet_2
{
     class InheritanceActivity
    {

        public static void Main(string[] args)
        {
            // Create a Manager object
            Manager manager = new Manager(101, "John Doe", "123 Main St", 1234567890, 50000);

            // Create a Trainee object
            Trainee trainee = new Trainee(102, "Jane Smith", "456 Oak Ave", 9876543210, 30000);

            // Calculate and display salaries
            Console.WriteLine($"Manager {manager.EmployeeName} Salary: {manager.CalculateSalary()}");
            Console.WriteLine($"Manager {manager.EmployeeName} Travel Allowance: {manager.CalculateTravelAllowance()}");

            Console.WriteLine($"\nTrainee {trainee.EmployeeName} Salary: {trainee.CalculateSalary()}");
            Console.WriteLine($"Trainee {trainee.EmployeeName} Travel Allowance: {trainee.CalculateTravelAllowance()}");
        }
    }
}
