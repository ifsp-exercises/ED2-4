using System.Linq;
using atividade_01.Models;

namespace atividade_01.Controllers
{
  public class SalesPersonController
  {
    private SalesPerson[] SalesPeople { get; set; }
    private int MaximumOfSalesPeople { get; set; }
    private int QuantityOfSalesPeople { get; set; }

    public SalesPersonController(int MaximumOfSalesPeople)
    {
      this.MaximumOfSalesPeople = MaximumOfSalesPeople;
      this.SalesPeople = new SalesPerson[this.MaximumOfSalesPeople];
      this.QuantityOfSalesPeople = 0;
    }

    public bool Create(SalesPerson salesPerson)
    {
      int countOfSalesPeople = this.SalesPeople.Where(sp => !Equals(sp, null)).Count();

      if (countOfSalesPeople == 10)
      {
        return false;
      }
      bool salesPersonExists = this.SalesPeople
        .Any(sp => salesPerson.Equals(sp));

      if (salesPersonExists) return false;

      this.SalesPeople[countOfSalesPeople] = salesPerson;

      return true;
    }

    public bool Destroy(SalesPerson salesPerson)
    {
      SalesPerson findSalesPerson = this.SalesPeople
        .FirstOrDefault(sp => salesPerson.Equals(sp));

      if (Equals(findSalesPerson, null)) return false;

      if (findSalesPerson.Sales.Any(sale => !Equals(sale, null))) return false;

      this.SalesPeople = this.SalesPeople
        .Where(sp => !salesPerson.Equals(sp)).ToArray();

      return true;
    }

    public bool Update(SalesPerson updatedSalesPerson)
    {
      bool salesPersonExists = this.SalesPeople
        .Any(salesPerson => updatedSalesPerson.Equals(salesPerson));

      if (!salesPersonExists) return false;

      this.SalesPeople = this.SalesPeople.Select(existingSalesPerson =>
        updatedSalesPerson.Equals(existingSalesPerson)
        ? updatedSalesPerson
        : existingSalesPerson
      ).ToArray();

      return true;
    }

    public SalesPerson[] Index() => this.SalesPeople
      .Where(salesPerson => !Equals(salesPerson, null))
      .Select(salesPerson => salesPerson.ClearNullSales())
      .ToArray();

    public SalesPerson Find(SalesPerson salesPerson) => this.SalesPeople
      .FirstOrDefault(sp => salesPerson.Equals(sp));

    public double GetSalesValue() => this.SalesPeople
      .Select(salesPerson => salesPerson.GetSalesValue()).Sum();

    public double GetCommissionsValue() => this.SalesPeople
      .Select(salesPerson => salesPerson.GetCommissionValue()).Sum();
  }
}
