using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.DAL.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> Select(Expression<Func<T, bool>> predicate = null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
