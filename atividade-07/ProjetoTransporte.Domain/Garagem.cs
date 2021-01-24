using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte.Domain
{
  public class Garagem
  {
    public Garagem(int id, string local)
    {
      Id = id;
      Local = local;
      Veiculos = new Stack<Veiculo>();
    }

    public int Id { get; set; }
    public string Local { get; set; }
    public Stack<Veiculo> Veiculos { get; set; }

    public int qtdeDeVeiculos()
    {
      return Veiculos.Count;
    }
  }
}
