using Data.Infrastructure;
using Data.Repository;
using Model.DTO;
using Model.Models;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {

        public readonly IEmployeeRepo EmployeeRepo;
        public readonly IUnitOfWork UnitOfWork;

        public EmployeeService(IEmployeeRepo employeeRepo,IUnitOfWork unitOfWork)
        {
            EmployeeRepo = employeeRepo;
            UnitOfWork = unitOfWork;
        }

        public Employee CreateEmployee(Employee entity)
        {
            return EmployeeRepo.Add(entity);
        }

        public void DeleteEmployee(int id)
        {
            EmployeeRepo.Delete(id);
        }

        public List<Employee> GetEmployees()
        {
            return EmployeeRepo.GetAll().ToList();
        }

        public PageResult<Employee> GetPageResult(int PageNumber, List<string> Includes = null, string PageDirection = "DSC")
        {
            return EmployeeRepo.GetPages(PageNumber, Includes, null,PageDirection);
        }

        public Employee UpdateEmployee(Employee entity)
        {
            return EmployeeRepo.Edit(entity.EmployeeID, entity);
        }

        public void SaveEmployeeData()
        {
            UnitOfWork.SaveChanges();
        }
    }
}
