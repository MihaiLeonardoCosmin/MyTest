using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI.WebControls;

namespace SCADT.Repository
{
    public abstract class BaseRepository<TEntity>
        where TEntity : class
    {
        protected DataBase context { get; private set; }
        public BaseRepository(DataBase date)
        {
            context = date;
        }
        public abstract TEntity Get(int id);
        public abstract IList<TEntity> GetList();

       

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var select = context.Set<TEntity>();
            var entity = select.Find(id);
            select.Remove(entity);
            context.SaveChanges();
        }

    }
}