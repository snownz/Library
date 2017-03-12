using Library.Domain.Data;
using Library.Domain.FilterException;
using Library.Domain.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Service
{
    public class CRUD<T> : IDbCRUD<T> where T : class, ITable
    {
        IRepository<T> _repository;

        public CRUD(IRepository<T> _repository)
        {
            this._repository = _repository;
        }

        public virtual async Task Delete(int id)
        {
            var model = _repository.GetById(id);
            if (model != null)
            {
                await _repository.DeleteAsync(model);
            }
            else
            {
                throw new ModelNotExistsException();
            }
        }

        public virtual IQueryable<T> ListAll()
        {
            return _repository.GetAll().Where(x=>x.Active);
        }

        public virtual async Task New(T model)
        {
            await _repository.InsertAsync(model);
        }

        public virtual async Task Update(T model)
        {
            var m = _repository.GetById(model.Id);
            if (m != null)
            {
                await _repository.UpdateAsync(model);
            }
            else
            {
                throw new ModelNotExistsException();
            }
        }

        public virtual T View(int id)
        {
            var model = _repository.GetById(id);

            if (model != null)
            {
                return model;
            }
            else
            {
                throw new ModelNotExistsException();
            }
        }
    }
}
