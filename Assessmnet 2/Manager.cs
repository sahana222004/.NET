using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessmnet_2
{
    internal class Manager : Employee
    {
        public Manager(long id, string name, string address, long phone, double salary)
        : base(id, name, address, phone, salary)
        {
        }

        public object EmployeeName { get; internal set; }

        // Override travel allowance for managers (15%)
        public override double CalculateTravelAllowance()
        {
            return basicSalary * 0.15;
        }
    }
}
