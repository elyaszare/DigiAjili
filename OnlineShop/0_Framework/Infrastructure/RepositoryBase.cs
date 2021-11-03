using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Infrastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext context;

        public RepositoryBase(DbContext context)
        {
            this.context = context;
        }

        public T Get(TKey id)
        {
            return context.Find<T>(id);
        }

        public List<T> Get()
        {
            return context.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            context.Add(entity);
        }

        public bool Exists(Expression<Func<T, bool>> exception)
        {
            return context.Set<T>().Any(exception);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
