using aula_01.Model;

namespace aula_01.Controller
{
  class CoisasController
  {
    private Coisa[] coisas { get; set; }
    public int maximo { get; private set; }
    public int quantidade { get; private set; }

    public CoisasController(int maximo)
    {
      this.maximo = maximo;
      this.quantidade = 0;
      this.coisas = new Coisa[this.maximo];

      for (int i = 0; i < this.maximo; i++)
      {
        this.coisas[i] = new Coisa(-1, "...");
      }
    }

    public string MostrarCoisas()
    {
      string resultado = string.Empty;

      foreach (Coisa coisa in this.coisas)
      {
        resultado += coisa.dados();
      }

      return resultado;
    }

    public bool AddCoisa(Coisa coisa)
    {
      bool podeAdicionar = this.quantidade < this.maximo;

      if (!podeAdicionar) return podeAdicionar;

      this.coisas[this.quantidade] = coisa;
      this.quantidade++;

      return podeAdicionar;
    }

    public bool DeleteCoisa(Coisa coisa)
    {
      bool temCoisa = false;

      foreach (Coisa c in this.coisas)
      {
        if (c.Id == coisa.Id)
        {
          c.Id = -1;
          c.Descricao = "...";
          temCoisa = true;
        }
      }

      return temCoisa;
    }

    public Coisa FindCoisa(Coisa coisa)
    {
      Coisa coisaEncontrada = new Coisa();

      foreach (Coisa c in this.coisas)
      {
        if (c.Equals(coisa))
        {
          coisaEncontrada = c;
          break;
        }
      }

      return coisaEncontrada;
    }
  }
}
