using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_7_______OOP_Generic_collections
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeGender { get; set; }
        public int EmployeeSalary { get; set; }

        public Employee(int employeeID, string employeeName, string employeeGender, int employeeSalary)
        {
            EmployeeId = employeeID;
            EmployeeName = employeeName;
            EmployeeGender = employeeGender;
            EmployeeSalary = employeeSalary;
        }

        public override string ToString()
        {
            return $"ID: {EmployeeId}, Namn: {EmployeeName}, Kön: {EmployeeGender}, inkomst: {EmployeeSalary}Kr/månad";
        }
    }
}
