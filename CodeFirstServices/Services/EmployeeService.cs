using System.Collections.Generic;
using CodeFirstData.DBInteractions;
using CodeFirstData.EntityRepositories;
using CodeFirstEntities;
using CodeFirstServices.Interfaces;

namespace CodeFirstServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IEmployeeRepository studentRepository, IUnitOfWork unitOfWork)
        {
            this._studentRepository = studentRepository;
            this._unitOfWork = unitOfWork;
        }  
        #region IStudentService Members

       
        public IEnumerable<Employee> GetEmployees()
        {
            var employees = _studentRepository.GetAll();
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _studentRepository.GetById(id);
            return employee;
        }

        public void CreateEmployee(Employee employee)
        {
            _studentRepository.Add(employee);
            _unitOfWork.Commit();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _studentRepository.GetById(id);
            _studentRepository.Delete(employee);
            _unitOfWork.Commit();
        }

        public void UpdateEmployee(Employee employee)
        {
            _studentRepository.Update(employee);
            _unitOfWork.Commit();
        }

        public void SaveEmployee()
        {
            _unitOfWork.Commit();
        }




        public IEnumerable<Employee> GetEmployeeByName(string Name)
        {

            var employees = _studentRepository.GetMany(x => x.Name == Name);
            return employees;
        }

        public IEnumerable<Employee> GetEmployeeByCode(int Code)
        {
            var employee = _studentRepository.Get(x => x.Code == Code);
            List<Employee> ListEmployees = new List<Employee>();
            ListEmployees.Add(employee);

            return (IEnumerable<Employee>)ListEmployees;
        }

        public IEnumerable<Employee> GetEmployeeByDateMajor(System.DateTime date)
        {

            var employees = _studentRepository.GetMany(x => x.StartDate > date);



            return employees;
        }


        

        
        #endregion
    }
}
