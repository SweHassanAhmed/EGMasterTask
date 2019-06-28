using Data.Infrastructure;
using Model.DTO;
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
    [RoutePrefix("api/call")]
    public class CallController : ApiController
    {
        private readonly ICallService CallService;
        private readonly IUnitOfWork UnitOfWork;

        public CallController(ICallService callService, IUnitOfWork unitOfWork)
        {
            CallService = callService;
            UnitOfWork = unitOfWork;
        }

        //api/call/getpatges/10/1
        [HttpGet]
        [Route("GetPages/{pageNumber}/{clientId}")]
        public PageResult<Call> GetPages(int pageNumber,int clientId)
        {
            var ListOfIncludes = new List<string>() { "Employee", "Client"};
            return CallService.GetPageResult(clientId, pageNumber, ListOfIncludes);
        }

        [HttpPost]
        public Call POST([FromBody]Call call)
        {
            call.EmployeeID = 1;
            CallService.CreateCall(call);

            UnitOfWork.SaveChanges();

            return call;
        }

    }
}
