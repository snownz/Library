using Library.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Sources
{
    public class CompanySource
    {
        private static CompanyViewModel Model0 = new CompanyViewModel() { Name = "Company1" };
        private static ICollection<CompanyViewModel> Models = new List<CompanyViewModel>
        {
            new CompanyViewModel {Name = "Company1"  },
            new CompanyViewModel {Name = "Company2"  },
            new CompanyViewModel {Name = "Company3"  },
            new CompanyViewModel {Name = "Company4"  },
            new CompanyViewModel {Name = "Company5"  },
            new CompanyViewModel {Name = "Company6"  },
            new CompanyViewModel {Name = "Company7"  },
            new CompanyViewModel {Name = "Company8"  },
            new CompanyViewModel {Name = "Company9"  },
            new CompanyViewModel {Name = "Company10"  },
            new CompanyViewModel {Name = "Company11"  },
            new CompanyViewModel {Name = "Company12"  },
            new CompanyViewModel {Name = "Company13"  },
        };
        
        public static object[] CompanyNewSource = new[]
        {
            new object[] { Model0, "Teste Inserir Novo Registro", "Company1"},
        };

        public static object[] CompanyDeleteSource = new[]
        {
            new object[] { Model0, 1, "Teste Deletar Registro"},
        };

        public static object[] CompanyUpdateSource = new[]
        {
            new object[] { Model0, "Company2", "Teste Alterar Registro", "Company2"},
        };

        public static object[] CompanyViewSource = new[]
        {
            new object[] { Model0, "Teste Vizualizar Registro"},
        };

        public static object[] CompanyGetAllSource = new[]
        {
            new object[] { Models, null, 1, "Teste Listar Registro", 10},
            new object[] { Models, null, 2, "Teste Listar Registro pagina 2", 3},
            new object[] { Models, "Company1", 1, "Teste Listar Registro Filtrado", 5},
            new object[] { Models, "Company", 1, "Teste Listar Registro Filtrado", 10},
        };
    }
}
