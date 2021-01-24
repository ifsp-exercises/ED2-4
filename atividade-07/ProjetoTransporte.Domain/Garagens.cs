using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransporte.Domain
{
  public class Garagens
  {
    public Garagens()
    {
      Garagems = new List<Garagem>();
      JornadaAtiva = false;
    }

    public List<Garagem> Garagems { get; set; }
    public bool JornadaAtiva { get; set; }

    public void incluir(Garagem garagem)
    {
      Garagems.Add(garagem);
    }
    public void iniciarJornada()
    {
      JornadaAtiva = true;
    }
    public List<Transporte> encerrarJornada()
    {
      JornadaAtiva = false;
      return null;
    }
  }
}
