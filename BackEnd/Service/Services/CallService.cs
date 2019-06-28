using Data.Infrastructure;
using Data.Repository;
using Model.DTO;
using Model.Models;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CallService : ICallService
    {
        private readonly ICallRepo CallRepo;
        private readonly IUnitOfWork UnitOfWork;

        public CallService(ICallRepo callRepo, IUnitOfWork unitOfWork)
        {
            CallRepo = callRepo;
            UnitOfWork = unitOfWork;
        }

        public Call CreateCall(Call entity)
        {
            return CallRepo.Add(entity);
        }

        public void DeleteCall(int id)
        {
            CallRepo.Delete(id);
        }

        public List<Call> GetCalls()
        {
            return CallRepo.GetAll().ToList();
        }

        public PageResult<Call> GetPageResult(int ClientID,int PageNumber, List<string> Includes, string OrderDirection = "DSC")
        {
            List<Expression<Func<Call, bool>>> ListOfFilter = new List<Expression<Func<Call, bool>>>();
            ListOfFilter.Add(a => a.ClientID == ClientID);

            return CallRepo.GetPages(PageNumber, Includes, ListOfFilter, OrderDirection);
        }

        public void SaveCallData()
        {
            UnitOfWork.SaveChanges();
        }

        public Call UpdateCall(Call entity)
        {
            return CallRepo.Edit(entity.CallID, entity);
        }
    }
}
