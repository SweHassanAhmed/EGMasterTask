using Model.DTO;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface ICallService
    {
        List<Call> GetCalls();
        Call CreateCall(Call entity);
        Call UpdateCall(Call entity);
        void DeleteCall(int id);
        PageResult<Call> GetPageResult(int ClientID, int PageNumber, List<string> Includes, string OrderDirection = "DSC");
        void SaveCallData();
    }
}
