using Library.Domain.Data;
using Library.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.DbConfig
{
    public class MockRepository<T> : IRepository<T> where T : ITable
    {
        public List<T> Ctx = new List<T>();

        public async Task DeleteAsync(T model)
        {
            await Task.Factory.StartNew(() =>
            {
                Ctx.Remove(model);
            });
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Task.Factory.StartNew(() =>
            {
                return Ctx.FirstOrDefault(x => x.Id == id);
            });
        }

        public async Task SaveAsync(T model)
        {
            await Task.Factory.StartNew(() =>
            {
                var m = Ctx.FirstOrDefault(x => x.Id == model.Id);
                if (m != null)
                {
                    Ctx.Remove(m);
                }
                else
                {
                    model.Id = Ctx.Count() + 1;
                }
                Ctx.Add(model);
            });
        }

        public void Insert(T model)
        {
            model.Id = Ctx.Count() + 1;
            Ctx.Add(model);
        }

        public void Update(T model)
        {
            Ctx.RemoveAll(x => x.Id == model.Id);
            Ctx.Add(model);
        }

        public virtual void Delete(T model)
        {
            Ctx.RemoveAll(x => x.Id == model.Id);
        }

        public T GetById(int id)
        {
            return Ctx.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return Ctx.AsQueryable();
        }

        public async Task InsertAsync(T model)
        {
            await Task.Factory.StartNew(() =>
            {
                model.Id = Ctx.Count() + 1;
                Ctx.Add(model);
            });
        }

        public async Task UpdateAsync(T model)
        {
            await Task.Factory.StartNew(() =>
            {
                Ctx.RemoveAll(x => x.Id == model.Id);
                Ctx.Add(model);
            });
        }
    }
}
