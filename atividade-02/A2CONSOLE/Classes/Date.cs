namespace A2CONSOLE.Classes
{
  public class Date
  {
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public void SetDate(int day, int month, int year)
    {
      this.Day = day;
      this.Month = month;
      this.Year = year;
    }

    public override string ToString() => $"{this.Day}/{this.Month}/{this.Year}";
  }
}
