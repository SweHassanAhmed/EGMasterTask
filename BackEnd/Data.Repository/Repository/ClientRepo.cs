using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClientRepo : BaseRespository<Client>, IClientRepo
    {
        public ClientRepo(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}
