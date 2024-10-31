namespace ExampleApp;

public class YearMonth
{
    public required int Year { get; set; }
    
    public required int Month { get; set; }

    public override string ToString() => $"{Month}.{Year}";
}

