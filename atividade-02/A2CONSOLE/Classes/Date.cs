namespace A2CONSOLE.Classes
{
  public class Date
  {
    public int Day { get; private set; }
    public int Month { get; private set; }
    public int Year { get; private set; }

    public void SetDate(int day, int month, int year)
    {
      this.Day = day;
      this.Month = month;
      this.Year = year;
    }

    public override string ToString() => $"{this.Day}/{this.Month}/{this.Year}";
  }
}
