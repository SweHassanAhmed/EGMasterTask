using Model.DTO;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IClientService
    {
        Client GetByID(int id);
        List<Client> GetClients();
        Client CreateClient(Client entity);
        Client UpdateClient(Client entity);
        void DeleteClient(int id);
        PageResult<Client> GetPageResult(int PageNumber, List<string> Includes = null, string PageDirection = "DSC");
        void SaveClientData();
    }
}
