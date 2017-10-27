using System.Collections.Generic;
using System.Linq;

namespace Eshop.Core
{
    public interface IRepository<T> where T:BaseEntity
    {
       
        T GetById(object id);

       
        void Insert(T entity);

        
        void Insert(IEnumerable<T> entities);

       
        void Update(T entity);

       
        void Update(IEnumerable<T> entities);

       
        void Delete(T entity);

       
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// 当前数据表
        /// </summary>
        IQueryable<T> Table { get; }

    }
}
