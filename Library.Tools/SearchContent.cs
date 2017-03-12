using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Tools
{
    public static class SearchContent
    {
        /// <summary>
        ///     Filtra uma Lista Usando Expressão Regular
        /// </summary>
        /// <param name="list"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static IEnumerable<ISearch> Filter(IEnumerable<ISearch> list, string search)
        {
            var pice = search.Split(' ');
            var pattern = "(" + string.Join("|", pice) + "){1,}";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return list.Where(x => regex.IsMatch(x.GetText));
        }

        /// <summary>
        ///     Filtra uma lista Iqueriable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static IEnumerable<T> FilterQuery<T>(IQueryable<T> list, string search) where T : ISearch
        {
            var pice = search.Split(' ');
            var pattern = "(" + string.Join("|", pice) + "){1,}";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return list.ToList().Where(x => regex.IsMatch(x.GetText));
        }
    }
}
