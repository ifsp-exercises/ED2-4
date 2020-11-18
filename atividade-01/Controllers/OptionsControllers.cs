using System.Linq;
using atividade_01.Models;

namespace atividade_01.Controllers
{
  public class OptionsController
  {
    private Option[] Options { get; set; }

    public OptionsController() => this.Options = new Option[] {
      new Option { Code= 0, Text="Sair" },
      new Option { Code= 1, Text="Cadastrar vendedor" },
      new Option { Code= 2, Text="Consultar vendedor" },
      new Option { Code= 3, Text="Excluir vendedor" },
      new Option { Code= 4, Text="Registrar venda" },
      new Option { Code= 5, Text="Listar vendedores" }
    };

    public Option[] Index() => this.Options;

    public bool ValidateOption(int optionCode) => this.Options
      .Any(option => option.Code.Equals(optionCode));
  }
}
