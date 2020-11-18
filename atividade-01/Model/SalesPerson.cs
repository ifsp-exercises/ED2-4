using System;
using System.Linq;

namespace atividade_01.Models
{
  public class SalesPerson
  {
    private static int lastIncludedId = 0;
    private static readonly int maximumOfSales = 31;

    private int Id { get; set; }
    private string Name { get; set; }
    private double CommissionPercentage { get; set; }
    public Sale[] Sales { get; private set; }

    public SalesPerson(int id)
    {
      this.Id = id;
      this.Name = null;
      this.CommissionPercentage = 0;
      this.Sales = null;
    }

    public SalesPerson(string name, double commissionPercentage)
    {
      this.Id = ++lastIncludedId;
      this.Name = name;
      this.CommissionPercentage = commissionPercentage;
      this.Sales = new Sale[SalesPerson.maximumOfSales];
    }

    public void RegisterSale(int day, Sale sale)
    {
      if (this.Sales.Length == maximumOfSales) throw new Exception(
        $"The maximum of {SalesPerson.maximumOfSales} sales has been reached."
      );

      this.Sales[this.Sales.Length] = sale;
    }

    public double GetSalesValue() => this.Sales.Select(sale => sale.Price).Sum();

    public double GetCommissionValue() => this.Sales
      .Select(sale => sale.Price * this.CommissionPercentage).Sum();

    public override bool Equals(object obj)
    {
      if (obj is not SalesPerson) return false;

      return this.Id.Equals(((SalesPerson)obj).Id);
    }

    public override int GetHashCode() => this.Id;

    public string ToJson() =>
      $"{{\n  \"Id\": {this.Id},\n  \"Name\": \"{this.Name}\",\n  \"CommissionPercentage\": {this.CommissionPercentage},\n  \"Sales\": []\n}}";
  }
}
