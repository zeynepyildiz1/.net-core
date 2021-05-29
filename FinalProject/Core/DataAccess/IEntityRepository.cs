using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint
    public interface IEntityRepository<T> where T:class, IEntity //must be referans type or IEntity
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter = null);
  
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}
