using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDBFactory dBFactory;
        public BaseEntity _dbContext;
        
        public BaseEntity DbContext => _dbContext ?? (_dbContext = dBFactory.Init());

        public UnitOfWork(IDBFactory dBFactory)
        {
            this.dBFactory = dBFactory;
        }
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }



    }
}
