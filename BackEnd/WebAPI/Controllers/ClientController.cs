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
    [RoutePrefix("api/client")]
    public class ClientController : ApiController
    {
        private readonly IClientService ClientService;
        private readonly IUnitOfWork UnitOfWork;

        public ClientController(IClientService clientService, IUnitOfWork unitOfWork)
        {
            ClientService = clientService;
            UnitOfWork = unitOfWork;
        }

        //api/Client/GetPages/10
        [HttpGet]
        [Route("GetPages/{pageNumber}")]
        public PageResult<Client> Get(int pageNumber)
        {        
            var ListOfIncludes = new List<string>() { "Employee" , "Calls.Employee" };
            return ClientService.GetPageResult(pageNumber,ListOfIncludes);
        }

        //api/client
        [HttpPost]
        public Client POST([FromBody]Client client)
        {
            ClientService.CreateClient(client);
            ClientService.SaveClientData();

            return client;
        }

        // api/client/GetClient/1
        [HttpGet]
        [Route("GetClient/{clientID}")]
        public Client GetClient(int clientID)
        {
            return ClientService.GetByID(clientID);
        }

        // api/client
        [HttpPut]
        public Client PUTClient([FromBody]Client client)
        {
            ClientService.UpdateClient(client);
            ClientService.SaveClientData();

            return client;
        }
    
        // api/client/2
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DELETEClient(int id)
        {
            ClientService.DeleteClient(id);
            ClientService.SaveClientData();
            return StatusCode(HttpStatusCode.NoContent);
        }




    }
}
