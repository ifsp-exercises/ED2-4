namespace aula_01.Model
{
  public class Coisa
  {
    public int Id { get; set; }
    public string Descricao { get; set; }

    public Coisa() : this(0, "") { }

    public Coisa(int id, string descricao)
    {
      this.Id = id;
      this.Descricao = descricao;
    }

    public string dados()
    {
      return $"{this.Id.ToString()} - {this.Descricao} \n";
    }

    public bool Equals(Coisa coisa) => this.Id.Equals(coisa.Id);
  }
}
