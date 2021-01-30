using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Models
{
  class Locacoes
  {
    private List<Locacao> contratos;

    public Locacoes()
    {
      contratos = new List<Locacao>();
    }

    public List<Locacao> Contratos
    {
      get { return contratos; }
      set { contratos = value; }
    }

    public void incluir(Locacao loc)
    {
      loc.Id = contratos.Count + 1;
      contratos.Add(loc);
    }

  }
}
