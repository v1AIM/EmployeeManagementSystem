using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{

    public abstract class Employee
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }

        public Employee(string employeeId, string name)
        {
            EmployeeId = employeeId;
            Name = name;
        }

        public abstract double CalculateSalary();
    }

    public class FullTimeEmployee : Employee
    {
        private double Monthlysalary;
        public FullTimeEmployee(string employeeId, string name,  double Monthlysalary) : base(employeeId, name)
        {
            this.Monthlysalary = Monthlysalary;
        }

        public override double CalculateSalary()
        {
            return Monthlysalary;
        }
    }

    public class PartTimeEmployee : Employee
    {
        private double HourlyRate;
        private double HoursWorked;
        public PartTimeEmployee(string employeeId, string name, double HourlyRate, double HoursWorked) : base(employeeId, name)
        {
            this.HourlyRate = HourlyRate;
            this.HoursWorked = HoursWorked;
        }

        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }

    public class EmployeeManagement
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmployee(string employeeId)
        {
            employees.RemoveAll(e => e.EmployeeId == employeeId);
            Console.WriteLine($"Employee with ID {employeeId} deleted");
        }


        public void ListAllEmployees()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.EmployeeId} , Name: {employee.Name}");

            }
        }
        public void ShowSalary()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name}'s salary is: {employee.CalculateSalary()}");

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            EmployeeManagement employeeManagement = new EmployeeManagement();

            employeeManagement.AddEmployee(new FullTimeEmployee("1", "Jhon" ,5000));
            employeeManagement.AddEmployee(new FullTimeEmployee("2", "Tony", 5000));
            employeeManagement.AddEmployee(new PartTimeEmployee("3", "Mark", 20 , 120));
            employeeManagement.AddEmployee(new PartTimeEmployee("4", "Harry", 10, 100));

            // List employees
            Console.WriteLine("All Employees: ");
            Console.WriteLine();
            employeeManagement.ListAllEmployees();
            Console.WriteLine();


            // Show salaries
            Console.WriteLine("Employees Salaries: ");
            Console.WriteLine();
            employeeManagement.ShowSalary();
            Console.WriteLine();

            // Remove employee
            employeeManagement.RemoveEmployee("1");
            Console.WriteLine();
            Console.WriteLine();


            // List employees
            Console.WriteLine("All employees After deletion: ");
            Console.WriteLine();
            employeeManagement.ListAllEmployees();


            Console.ReadKey();
        }
    }
}
