using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Data
{
    public interface ITable
    {
        int Id { get; set; }
        bool Active { get; set; }
    }
}
