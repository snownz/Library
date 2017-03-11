using Library.Domain.Data;
using Library.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.DbConfig
{
    public class Repository<T> : IRepository<T> where T : class, ITable
    {
        private LibraryContext Ctx = new LibraryContext();

        [DbValidator]
        public async Task DeleteAsync(T model)
        {
            Ctx.Entry(model).State = EntityState.Modified;
            await SaveAsync(model);
        }
        [DbValidator]
        public async Task<T> GetByIdAsync(int id)
        {
            return await Ctx.Set<T>().FindAsync(id);
        }
        [DbValidator]
        public async Task SaveAsync(T model)
        {
            if (model.Id != -1)
            {
                var entity = Ctx.Set<T>().Find(model.Id);

                if (entity != null)
                {
                    var entry = Ctx.Entry(entity);
                    entry.CurrentValues.SetValues(model);
                }
            }
            else
            {
                Ctx.Set<T>().Add(model);
            }
            Ctx.SaveChanges();
            await Ctx.SaveChangesAsync();
        }
        [DbValidator]
        public void Insert(T model)
        {
            Ctx.Entry(model).State = EntityState.Added;
            Ctx.SaveChanges();
        }
        [DbValidator]
        public void Update(T model)
        {
            Ctx.Entry(model).State = EntityState.Modified;
            Ctx.SaveChanges();
        }
        [DbValidator]
        public virtual void Delete(T model)
        {
            model.Active = false;
            Update(model);
        }
        [DbValidator]
        public T GetById(int id)
        {
            return Ctx.Set<T>().Find(id);
        }
        [DbValidator]
        public IQueryable<T> GetAll()
        {
            return Ctx.Set<T>();
        }
        [DbValidator]
        public async Task InsertAsync(T model)
        {
            Ctx.Entry(model).State = EntityState.Added;
            await Ctx.SaveChangesAsync();
        }
        [DbValidator]
        public async Task UpdateAsync(T model)
        {
            Ctx.Entry(model).State = EntityState.Modified;
            await Ctx.SaveChangesAsync();
        }
    }
}
