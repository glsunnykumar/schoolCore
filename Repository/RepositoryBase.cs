using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entities;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext repositoryContext { get; set; }

        public RepositoryBase(RepositoryContext Context)
        {
            this.repositoryContext = Context;
        }

        public void Create(T entity)
        {
            this.repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.repositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this.repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCollection(Expression<Func<T, bool>> expression)
        {
            return this.repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this.repositoryContext.Set<T>().Update(entity);
        }
    }
}
