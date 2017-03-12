using AutoMapper;
using Library.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Presentation.Models.Pagination
{
    public class PaginationData<T, K> where T : ISearch
    {
        private readonly Func<IQueryable<T>> _carregarDados;
        /// <summary>
        ///     Quantidade Maxima de Registros por pagina
        /// </summary>
        public int QuantidadeMaxima { get; set; } = 10;
        /// <summary>
        ///     Quantidade de Paginas
        /// </summary>
        public int QuantidadePaginas
        {
            get
            {
                return (int)Math.Ceiling((double)ColecaoQauntidade / QuantidadeMaxima);
            }
        }
        /// <summary>
        ///     Quantidade de Dados
        /// </summary>
        public int ColecaoQauntidade
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Busca))
                {
                    return SearchContent.FilterQuery(_carregarDados(), Busca).Count();
                }
                else
                {
                    return _carregarDados().Count();
                }
            }
        }
        /// <summary>
        ///     Enumerador onde está a Query dos dados
        /// </summary>
        public IEnumerable<T> Colecao
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Busca))
                {
                    return SearchContent.FilterQuery(_carregarDados(), Busca).Skip((PaginaAtual - 1) * QuantidadeMaxima).Take(QuantidadeMaxima);
                }
                else
                {
                    return _carregarDados().Skip((PaginaAtual - 1) * QuantidadeMaxima).Take(QuantidadeMaxima);
                }
            }
        }
        /// <summary>
        ///     Lista de Paginas
        /// </summary>
        public int?[] Paginas
        {
            get
            {
                var quantidades = QuantidadePaginas;
                var dados = new int?[quantidades];

                for (int i = 0; i < quantidades; i++)
                {
                    dados[i] = i + 1;
                }
                return dados;
            }
        }
        /// <summary>
        ///     String de Busca
        /// </summary>
        public string Busca { get; set; }
        /// <summary>
        ///     Pagina Atual
        /// </summary>
        public int PaginaAtual { get; set; }
        /// <summary>
        ///     Dados em forma de Lista
        /// </summary>
        public List<K> Dados { get { return Mapper.Map<List<K>>(Colecao.ToList()); } }
        /// <summary>
        ///     Construtor
        /// </summary>
        /// <param name="_carregarDados">Função onde os dados serão Carregados</param>
        public PaginationData(Func<IQueryable<T>> _carregarDados)
        {
            this._carregarDados = _carregarDados;
        }
    }
}