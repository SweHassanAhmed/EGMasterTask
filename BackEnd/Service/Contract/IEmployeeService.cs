using Model.DTO;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Employee CreateEmployee(Employee entity);
        Employee UpdateEmployee(Employee entity);
        void DeleteEmployee(int id);
        PageResult<Employee> GetPageResult(int PageNumber, List<string> Includes = null, string PageDirection = "DES");
        void SaveEmployeeData();

    }
}
