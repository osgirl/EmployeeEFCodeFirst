using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeFirstEntities;

namespace CodeFirstServices.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> GetEmployeeByName(string Name);
        IEnumerable<Employee> GetEmployeeByCode(int Code);
        IEnumerable<Employee> GetEmployeeByDateMajor(DateTime date);

        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
        void SaveEmployee();


    }
}
