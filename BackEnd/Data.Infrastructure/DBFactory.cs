﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class DBFactory : IDisposable, IDBFactory
    {
        private BaseEntity _dbContext;

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public BaseEntity Init()
        {
            return _dbContext ?? (_dbContext = CreateDBContext());
        }

        private BaseEntity CreateDBContext()
        {
            return new BaseEntity();
        }
    }
}
