using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte.Domain
{
  public class Veiculo
  {

    public Veiculo()
    {
      Id = 0;
      Placa = "";
      Lotacao = 0;
    }
    public Veiculo(int id, string placa, int lotacao)
    {
      Id = id;
      Placa = placa;
      Lotacao = lotacao;
    }

    public int Id { get; set; }
    public string Placa { get; set; }
    public int Lotacao { get; set; }
  }
}
