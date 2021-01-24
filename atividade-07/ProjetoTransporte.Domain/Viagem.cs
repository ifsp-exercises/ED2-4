namespace ProjetoTransporte.Domain
{
  public class Viagem
  {
    public Viagem(int id, Garagem origem, Garagem destino, Veiculo veiculo)
    {
      Id = id;
      Origem = origem;
      Destino = destino;
      Veiculo = veiculo;
    }

    public int Id { get; set; }
    public Garagem Origem { get; set; }
    public Garagem Destino { get; set; }
    public Veiculo Veiculo { get; set; }
  }
}
