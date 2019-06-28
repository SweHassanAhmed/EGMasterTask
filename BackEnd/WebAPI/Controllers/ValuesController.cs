using AutoMapper;
using Data.Infrastructure;
using Data.Repository;
using Model.DTO;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        IEmployeeRepo ClientRepo;
        IUnitOfWork unitOfWork;
        public ValuesController(IEmployeeRepo clientRepo, IUnitOfWork unitOfWork)
        {
            ClientRepo = clientRepo;
            this.unitOfWork = unitOfWork;
        }

        // GET api/values
        //public PageResult<Employee> Get()
        //{
        //    //ClientRepo.Add(new Employee { Name = "sds"});
        //    //unitOfWork.SaveChanges();

        //    //return ClientRepo.GetPages(1);
        //    //return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //public PageResult<Employee> Get(int id)
        //{
        //    return ClientRepo.GetPages(id);
        //}

        // POST api/values
        public void Post([FromBody]Employee emp)
        {
            ClientRepo.Add(emp);
            unitOfWork.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
