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
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IClientRepo ClientRepo;

        public ClientService(IClientRepo clientRepo, IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            ClientRepo = clientRepo;
        }

        public Client GetByID(int id)
        {
            return ClientRepo.GetById(id);
        }


        public Client CreateClient(Client entity)
        {
            // Bring The Employee Id From The Session If Exist
            entity.EmployeeID = 1;

            if(entity.Calls != null)
                for (int i = 0; i < entity.Calls.Count; i++)
                    entity.Calls[i].EmployeeID = 1;

            return ClientRepo.Add(entity);
        }

        public void DeleteClient(int id)
        {
            ClientRepo.Delete(id);
        }

        public List<Client> GetClients()
        {
            return ClientRepo.GetAll().ToList();
        }

        public PageResult<Client> GetPageResult(int PageNumber,List<string> Includes = null, string PageDirection = "DSC")
        {
            return ClientRepo.GetPages(PageNumber,Includes,null,PageDirection);
        }

        public void SaveClientData()
        {
            UnitOfWork.SaveChanges();
        }

        public Client UpdateClient(Client entity)
        {
            return ClientRepo.Edit(entity.ClientID, entity);
        }
    }
}
