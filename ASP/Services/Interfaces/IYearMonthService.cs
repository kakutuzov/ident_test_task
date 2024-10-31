namespace ExampleApp;

public interface IYearMonthService
{
    string EchoYearMonth(TestFilter date);

    string EchoDefaultYearMonth();
}
