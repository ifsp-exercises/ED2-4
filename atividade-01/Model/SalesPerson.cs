using System;
using System.Linq;

namespace atividade_01.Models
{
  public class SalesPerson
  {
    private static int lastIncludedId = 0;
    private static readonly int maximumOfSales = 31;

    public int Id { get; private set; }
    public string Name { get; private set; }
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

    public void RegisterSale(Sale sale)
    {
      int quantityOfSales = this.Sales.Where(sale => !Equals(sale, null)).Count();

      if (quantityOfSales == maximumOfSales) throw new Exception(
        $"The maximum of {SalesPerson.maximumOfSales} sales has been reached."
      );

      this.Sales[quantityOfSales] = sale;
    }

    public double GetSalesValue() => this.Sales.Select(sale => sale.Price).Sum();

    public double GetCommissionValue() => this.Sales
      .Select(sale => sale.Price * this.CommissionPercentage).Sum();

    public override bool Equals(object obj)
    {
      if (Equals(obj, null)) return false;

      if (obj is not SalesPerson) return false;

      return this.Id.Equals(((SalesPerson)obj).Id);
    }

    public override int GetHashCode() => this.Id;

    public SalesPerson ClearNullSales()
    {
      SalesPerson cleanSalesPerson = new SalesPerson(Id);

      cleanSalesPerson.Name = this.Name;
      cleanSalesPerson.CommissionPercentage = this.CommissionPercentage;

      cleanSalesPerson.Sales = this.Sales
        .Where(sale => !Equals(sale, null)).ToArray();

      return cleanSalesPerson;
    }

    public string ToJson()
    {
      double totalSalesValue = this.Sales
        .Where(sale => !Equals(sale, null)).Select(sale => sale.Price).Sum();

      double totalCommissionValue = this.Sales
        .Where(sale => !Equals(sale, null))
        .Select(sale => sale.Price * this.CommissionPercentage / 100).Sum();

      string salesAverageValues = string.Join(
        "\n  ",
        this.Sales
        .Where(sale => !Equals(sale, null))
        .Select(sale => $"{{{sale.CalculateAveragePrice()}}},")
      );

      return $"{{\n  \"Id\": {this.Id},\n  \"Name\": \"{this.Name}\",\n  \"CommissionPercentage\": {this.CommissionPercentage},\n  \"totalSalesValue\": {totalSalesValue},\n  \"totalCommissionValue\": {totalCommissionValue},\n  \"salesAverageValues\": [\n    {salesAverageValues}\n  ]\n}}";
    }
  }
}
