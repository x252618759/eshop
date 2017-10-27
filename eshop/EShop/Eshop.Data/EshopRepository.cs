using Eshop.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data
{
    public class EshopRepository<T> : IRepository<T> where T:BaseEntity
    {
        IDbContext context;
        private IDbSet<T> _entities;
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = context.Set<T>();
                return _entities;
            }
        }
        public EshopRepository(IDbContext dbContext)
        {
            context = dbContext;
        }

        public IQueryable<T> Table
        {
            get
            {                
                return Entities;
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)          
                throw new Exception("entity is null");
           
            Entities.Remove(entity);
            context.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            if (entities == null)           
                throw new Exception("entities is null");
           
            foreach (var entity in entities)           
                Entities.Remove(entity);
                     
            context.SaveChanges();
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)            
                throw new Exception("entity is null");
            Entities.Add(entity);
            
        }

        public void Insert(IEnumerable<T> entities)
        {
           if(entities == null)
                throw new Exception("entities is null");
            foreach (var entity in entities)            
                Entities.Add(entity);
           
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        public string GetFullErrorText(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg += string.Format("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
            return msg;
        }
    }
}
