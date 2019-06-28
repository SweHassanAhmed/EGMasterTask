using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CallRepo : BaseRespository<Call>, ICallRepo
    {
        public CallRepo(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}
