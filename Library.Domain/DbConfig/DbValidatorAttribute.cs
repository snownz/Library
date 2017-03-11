using Library.Domain.FilterException;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnRatingtions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.DbConfig
{
    /// <summary>
    ///     Atributo de validação do Contexto
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    class DbValidatorAttribute : ValidationAttribute
    {
        private readonly LibraryContext _ctx = new LibraryContext();

        public override bool IsValid(object value)
        {
            if (!_ctx.Database.Exists())
                throw new DataBaseNotInitializedException("Database not exists in the server configured. See the WebConfig or AppConfig");
            return true;
        }
    }
}
