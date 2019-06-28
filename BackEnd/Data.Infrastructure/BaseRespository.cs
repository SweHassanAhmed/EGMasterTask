using Model.DTO;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class BaseRespository<T> : IBaseRespository<T> where T : BaseModel
    {
        #region Properties

        private BaseEntity _DataContext;
        private readonly DbSet<T> DbSet;
        private IDBFactory DBFactory;

        protected BaseEntity DataContext
        {
            get { return _DataContext ?? (_DataContext = DBFactory.Init()); }
        }

        #endregion

        public BaseRespository(IDBFactory dBFactory)
        {
            DBFactory = dBFactory;
            DbSet = DataContext.Set<T>();
        }

        public T Add(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModificationDate = DateTime.Now;

            // Get The User Created This Object

            DbSet.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if(entity != null)
            {
                entity.IsDeleted = true;
                Edit(id, entity);
            }
        }

        public T Edit(int id,T entity)
        {
            var local = DbSet.Find(id);
            if (local != null)
            {
                DataContext.Entry(local).State = EntityState.Detached;
            }
            entity.ModificationDate = DateTime.Now;
            entity.CreatedBy = local.CreatedBy;
            entity.CreatedDate = local.CreatedDate;

            DbSet.Attach(entity);

            _DataContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.Where(a => a.IsDeleted == false).AsNoTracking().AsEnumerable();
        }

        public virtual T GetById(int id)
        {
            var Element = DbSet.Find(id);

            if (Element != null)
                if (Element.IsDeleted == false)
                    return Element;

            return null;
        }

        public PageResult<T> GetPages(int PageNumber,List<string> Includes, List<Expression<Func<T,bool>>> filters = null, string OrderDirection = "DSC")
        {
            PageResult<T> PageResult = new PageResult<T>();
            IQueryable<T> Query = DbSet.AsQueryable();

            Query = Query.Where(a => a.IsDeleted == false).AsNoTracking();

            if(filters != null)
                foreach (var filter in filters)
                    Query = Query.Where(filter);

            if(Includes != null)
                foreach (var item in Includes)
                    Query = Query.Include(item);
                

            if (OrderDirection == "DSC")
                Query = Query.OrderByDescending(a => a.ModificationDate);
            else
                Query = Query.OrderBy(a => a.ModificationDate);

            PageResult.TotalRecords = Query.Count();

            Query = Query.Skip((PageNumber - 1) * 10);

            PageResult.Results = Query.Take(10).ToList();

            return PageResult;
        }
    }
}
