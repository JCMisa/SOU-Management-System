using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //get all
        IEnumerable<T> GetAll(string? includeProperties = null);

        //get single
        T Get(Expression<Func<T,bool>> filter, string? includeProperties = null);

        //add data
        void Add(T entity);

        //delete data
        void Remove(T entity);

        //delete multiple
        void RemoveRange(IEnumerable<T> entities);
    }
}
