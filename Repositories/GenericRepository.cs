using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DotNetVueBlog.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
       private readonly IUnitOfWork _unitOfWork;
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }
 
        public void Delete(T entity)
        {
            T existing = _unitOfWork.Context.Set<T>().Find(entity);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
        }
 
        public IEnumerable<T> Get()
        {
            return _unitOfWork.Context.Set<T>().AsEnumerable<T>();
        }
 
        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable<T>();
        }
 
        public void Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
        }
    }
}