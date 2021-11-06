using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepository<TKey, T> where T : class
    {
        T Get(TKey id);

        //ProductCategory Get(Long id);
        List<T> Get();

        //List<ProductCategory> Get();
        void Create(T entity);

        //void Create(ProductCategory entity);
        bool Exists(Expression<Func<T, bool>> exception);
        void SaveChanges();
    }
}
