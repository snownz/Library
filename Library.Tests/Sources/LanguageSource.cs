using Library.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Sources
{
    public class LanguageSource
    {
        private static LanguageViewModel Model0 = new LanguageViewModel() { Description = "Language1" };
        private static ICollection<LanguageViewModel> Models = new List<LanguageViewModel>
        {
            new LanguageViewModel {Description = "Language1"  },
            new LanguageViewModel {Description = "Language2"  },
            new LanguageViewModel {Description = "Language3"  },
            new LanguageViewModel {Description = "Language4"  },
            new LanguageViewModel {Description = "Language5"  },
            new LanguageViewModel {Description = "Language6"  },
            new LanguageViewModel {Description = "Language7"  },
            new LanguageViewModel {Description = "Language8"  },
            new LanguageViewModel {Description = "Language9"  },
            new LanguageViewModel {Description = "Language10"  },
            new LanguageViewModel {Description = "Language11"  },
            new LanguageViewModel {Description = "Language12"  },
            new LanguageViewModel {Description = "Language13"  },
        };
        
        public static object[] LanguageNewSource = new[]
        {
            new object[] { Model0, "Teste Inserir Novo Registro", "Language1"},
        };

        public static object[] LanguageDeleteSource = new[]
        {
            new object[] { Model0, 1, "Teste Deletar Registro"},
        };

        public static object[] LanguageUpdateSource = new[]
        {
            new object[] { Model0, "Language2", "Teste Alterar Registro", "Language2"},
        };

        public static object[] LanguageViewSource = new[]
        {
            new object[] { Model0, "Teste Vizualizar Registro"},
        };

        public static object[] LanguageGetAllSource = new[]
        {
            new object[] { Models, null, 1, "Teste Listar Registro", 10},
            new object[] { Models, null, 2, "Teste Listar Registro pagina 2", 3},
            new object[] { Models, "Language1", 1, "Teste Listar Registro Filtrado", 5},
            new object[] { Models, "Language", 1, "Teste Listar Registro Filtrado", 10},
        };
    }
}
