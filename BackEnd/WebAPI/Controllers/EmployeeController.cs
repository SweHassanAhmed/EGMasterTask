using Data.Infrastructure;
using Model.Models;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService EmployeeService;
        private readonly IUnitOfWork UnitOfWork;

        public EmployeeController(IEmployeeService employeeService, IUnitOfWork unitOfWork)
        {
            EmployeeService = employeeService;
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetList")]
        public List<Employee> GET()
        {
            return EmployeeService.GetEmployees();
        }


    }
}
