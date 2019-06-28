using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public interface IBaseRespository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Edit(int id,T entity);
        void Delete(int id);
        PageResult<T> GetPages(int PageNumber, List<string> Includes, List<Expression<Func<T, bool>>> filters = null, string OrderDirection = "DSC");
    }
}
