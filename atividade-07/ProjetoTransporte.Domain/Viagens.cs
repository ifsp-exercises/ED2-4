using System.Collections.Generic;


namespace ProjetoTransporte.Domain
{
  public class Viagens
  {
    public Viagens()
    {
      ViagensQueue = new Queue<Viagem>();
    }
    public Queue<Viagem> ViagensQueue { get; set; }

    public void incluir(Viagem viagem)
    {
      ViagensQueue.Enqueue(viagem);
    }
  }
}
