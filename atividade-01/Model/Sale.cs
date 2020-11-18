namespace atividade_01.Models
{
  public class Sale
  {
    private int Quantity { get; set; }
    public double Price { get; private set; }

    public double CalculateAveragePrice() => this.Price / this.Quantity;

    public Sale(int quantity, double price)
    {
      this.Quantity = quantity;
      this.Price = price;
    }
  }
}
