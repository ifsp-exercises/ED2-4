using System.Collections.Generic;
using System.Linq;
using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Controllers
{
  public class SenhaController
  {
    private int _proximoAtendimento;
    public readonly Queue<Senha> FilaSenhas;

    public SenhaController()
    {
      _proximoAtendimento = 1;
      FilaSenhas = new Queue<Senha>();
    }

    public Senha Gerar(){
      FilaSenhas.Enqueue(new Senha(_proximoAtendimento++));

      return FilaSenhas.Last();
    }
  }
}