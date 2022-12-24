using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.BL.Abstract
{
    public interface IGenericManager<T>
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Select(Expression<Func<T,bool>>predicate = null);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
