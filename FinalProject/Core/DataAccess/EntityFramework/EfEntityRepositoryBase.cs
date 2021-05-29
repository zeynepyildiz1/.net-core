using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()//newlenebilir
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//veri kaynagiyla eslestir,referansi yakala
                addedEntity.State = EntityState.Added;//ekleme islemini sec
                context.SaveChanges();//degisiklikleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//veri kaynagiyla eslestir,referansi yakala
                deletedEntity.State = EntityState.Deleted;//ekleme islemini sec
                context.SaveChanges();//degisiklikleri kaydet
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().SingleOrDefault(filter)
                     : context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList()
                     : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//veri kaynagiyla eslestir,referansi yakala
                updatedEntity.State = EntityState.Modified;//ekleme islemini sec
                context.SaveChanges();//degisiklikleri kaydet
            }
        }
    }
}
