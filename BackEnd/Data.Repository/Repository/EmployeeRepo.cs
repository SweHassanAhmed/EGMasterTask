using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EmployeeRepo : BaseRespository<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}
