namespace atividade_01.Models
{
  public class Sale
  {
    private int Quantity { get; set; }
    public double Price { get; private set; }

    public double CalculateAveragePrice() => this.Price / this.Quantity;
  }
}
