using System.Collections.Generic;

namespace Atendimento.Domain.Entities
{
  public class Guiche
  {
    private readonly int _id;
    private readonly Queue<Senha> _atendimentos;

    public Guiche()
    {
      _id = 0;
      _atendimentos = new Queue<Senha>();
    }

    public Guiche(int id) : this()
    {
      _id = id;
    }

    public bool Chamar(Queue<Senha> filaSenhas)
    {
      filaSenhas.TryDequeue(out Senha senhaRetirada);

      if (senhaRetirada == null)
        return false;

      _atendimentos.Enqueue(senhaRetirada);

      return true;
    }
  }
}