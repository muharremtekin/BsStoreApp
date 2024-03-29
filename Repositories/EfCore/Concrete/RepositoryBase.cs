﻿using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.EfCore.Concrete
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryContext _repositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(T entity) => _repositoryContext.Set<T>().AddAsync(entity);

        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);

        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            _repositoryContext.Set<T>().AsNoTracking() :
            _repositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            _repositoryContext.Set<T>().Where(expression).AsNoTracking() :
            _repositoryContext.Set<T>().Where(expression);
    }
}
