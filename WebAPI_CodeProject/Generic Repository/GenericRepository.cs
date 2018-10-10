using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI_CodeProject.Generic_Repository
{
    public class GenericRepository<TEntity> where TEntity : class

    {
        private WebApiDbEntities context;
        private DbSet<TEntity> DbSet;

        public GenericRepository(WebApiDbEntities context)
        {
            this.context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return DbSet.ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }


        public virtual void Delete(object id)
        {
            TEntity entity = DbSet.Find(id);
            Delete(entity);

        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);

        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return DbSet.Where(where);
        }


        public virtual TEntity Get(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).FirstOrDefault();
        }

        public virtual void Delete(Func<TEntity, bool> where)
        {
            IEnumerable<TEntity> objects = DbSet.Where(where);
            foreach (TEntity obj in objects)
            {
                DbSet.Remove(obj);
            }
        }


    }
}
