using System.Collections.Generic;
using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Controllers
{
  public class SenhaController
  {
    private int _proximoAtendimento;
    private readonly Queue<Senha> _filaSenhas;

    public SenhaController()
    {
      _proximoAtendimento = 1;
      _filaSenhas = new Queue<Senha>();
    }

    public void Gerar() => 
      _filaSenhas.Enqueue(new Senha(_proximoAtendimento++));
  }
}