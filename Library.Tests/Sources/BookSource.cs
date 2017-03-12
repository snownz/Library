using Library.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Sources
{
    public class BookSource
    {
        private static BookViewModel Model0 = new BookViewModel() { Name = "Book1" };
        private static ICollection<BookViewModel> Models = new List<BookViewModel>
        {
            new BookViewModel {Name = "Book1"  },
            new BookViewModel {Name = "Book2"  },
            new BookViewModel {Name = "Book3"  },
            new BookViewModel {Name = "Book4"  },
            new BookViewModel {Name = "Book5"  },
            new BookViewModel {Name = "Book6"  },
            new BookViewModel {Name = "Book7"  },
            new BookViewModel {Name = "Book8"  },
            new BookViewModel {Name = "Book9"  },
            new BookViewModel {Name = "Book10"  },
            new BookViewModel {Name = "Book11"  },
            new BookViewModel {Name = "Book12"  },
            new BookViewModel {Name = "Book13"  },
        };
        
        public static object[] BookNewSource = new[]
        {
            new object[] { Model0, "Teste Inserir Novo Registro", "Book1"},
        };

        public static object[] BookDeleteSource = new[]
        {
            new object[] { Model0, 1, "Teste Deletar Registro"},
        };

        public static object[] BookUpdateSource = new[]
        {
            new object[] { Model0, "Book2", "Teste Alterar Registro", "Book2"},
        };

        public static object[] BookViewSource = new[]
        {
            new object[] { Model0, "Teste Vizualizar Registro"},
        };

        public static object[] BookGetAllSource = new[]
        {
            new object[] { Models, null, 1, "Teste Listar Registro", 10},
            new object[] { Models, null, 2, "Teste Listar Registro pagina 2", 3}
        };
    }
}
