using System.Collections.Generic;

namespace Atendimento.Domain.Entities
{
  public class Guiche
  {
    private static int _promixoId = 0;
    public int Id { get; }
    private readonly Queue<Senha> _atendimentos;

    public IReadOnlyCollection<Senha> Atendimentos { get => _atendimentos.ToArray(); }

    public Guiche()
    {
      Id = ++_promixoId;
      _atendimentos = new Queue<Senha>();
    }

    public Guiche(int id) : this()
    {
      Id = id;
    }

    public bool Chamar(Queue<Senha> filaSenhas)
    {
      filaSenhas.TryDequeue(out Senha senhaRetirada);

      if (senhaRetirada == null)
        return false;

      senhaRetirada.AtualizarDataAtendimento();
      _atendimentos.Enqueue(senhaRetirada);

      return true;
    }
  }
}