using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte.Domain
{
  public class Veiculos
  {
    public Veiculos()
    {
      VeiculosList = new List<Veiculo>();
    }
    public List<Veiculo> VeiculosList { get; private set; }

    public bool incluir(Veiculo veiculo)
    {
      try
      {
        VeiculosList.Add(veiculo);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
