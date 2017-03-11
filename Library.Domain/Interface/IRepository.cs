using Library.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interface
{
    /// <summary>
    ///     Interface de Repositório
    /// </summary>
    /// <typeparam name="T">Tipo consumindo a interface</typeparam>
    public interface IRepository<T> where T : ITable
    {
        /// <summary>
        ///     Busca dados com a chave 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);
        /// <summary>
        ///     Deleta o objeto (Asincrono)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task DeleteAsync(T model);
        /// <summary>
        ///     Salva o objeto (Asincrono)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task SaveAsync(T model);
        /// <summary>
        ///     Insere o objeto 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Insert(T model);
        /// <summary>
        ///     Altera o objeto 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(T model);
        /// <summary>
        ///     Insere o objeto (Asincrono)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task InsertAsync(T model);
        /// <summary>
        ///     Deleta o objeto (Asincrono)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateAsync(T model);
         /// <summary>
        ///     Deleta o objeto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(T model);
        /// <summary>
        ///     Lista todos os objetos
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
        /// <summary>
        ///     Busca Todos os osbjetos pela chave
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);
    }
}
