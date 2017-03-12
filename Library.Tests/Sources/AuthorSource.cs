using Library.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Sources
{
    public class AuthorSource
    {
        private static AuthorViewModel Model0 = new AuthorViewModel() { Name = "Autor1" };
        private static ICollection<AuthorViewModel> Models = new List<AuthorViewModel>
        {
            new AuthorViewModel {Name = "Autor1"  },
            new AuthorViewModel {Name = "Autor2"  },
            new AuthorViewModel {Name = "Autor3"  },
            new AuthorViewModel {Name = "Autor4"  },
            new AuthorViewModel {Name = "Autor5"  },
            new AuthorViewModel {Name = "Autor6"  },
            new AuthorViewModel {Name = "Autor7"  },
            new AuthorViewModel {Name = "Autor8"  },
            new AuthorViewModel {Name = "Autor9"  },
            new AuthorViewModel {Name = "Autor10"  },
            new AuthorViewModel {Name = "Autor11"  },
            new AuthorViewModel {Name = "Autor12"  },
            new AuthorViewModel {Name = "Autor13"  },
        };
        
        public static object[] AuthorNewSource = new[]
        {
            new object[] { Model0, "Teste Inserir Novo Registro", "Autor1"},
        };

        public static object[] AuthorDeleteSource = new[]
        {
            new object[] { Model0, 1, "Teste Deletar Registro"},
        };

        public static object[] AuthorUpdateSource = new[]
        {
            new object[] { Model0, "Autor2", "Teste Alterar Registro", "Autor2"},
        };

        public static object[] AuthorViewSource = new[]
        {
            new object[] { Model0, "Teste Vizualizar Registro"},
        };

        public static object[] AuthorGetAllSource = new[]
        {
            new object[] { Models, null, 1, "Teste Listar Registro", 10},
            new object[] { Models, null, 2, "Teste Listar Registro pagina 2", 3},
            new object[] { Models, "Autor1", 1, "Teste Listar Registro Filtrado", 5},
            new object[] { Models, "Autor", 1, "Teste Listar Registro Filtrado", 10},
        };
    }
}
