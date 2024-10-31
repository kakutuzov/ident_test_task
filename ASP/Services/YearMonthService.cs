namespace ExampleApp;

public class YearMonthService : IYearMonthService
{
    private const string DefaultValue = "1.1970";

    public YearMonthService()
    {
    }

    public string EchoYearMonth(TestFilter date)
    {
        try
        {
            return getYearMonth(date);
        }
        catch (Exception ex)
        {
            /*Log the exeption*/
            return DefaultValue;
        }
    }

    public string EchoDefaultYearMonth() => DefaultValue;

    private string getYearMonth(TestFilter date) 
    {
        var value = date.YearMonth;
        if (value == null)
            return DefaultValue;

        if (value.Year < 1970)
        {
            return DefaultValue;
        }
        if(value.Month < 1 || value.Month > 12)
        {
            return DefaultValue;
        }

        return date.YearMonth.ToString();
    }
}
