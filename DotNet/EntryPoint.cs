using System.Diagnostics;

namespace IDENT;

internal class EntryPoint
{
    static void Main(string[] args)
    {
        var pacients = DataPool.GeneratePacientData();
        var receptions = DataPool.GenerateReceptionData();

        var msVariant = new MSTraditionFinder();
        var siplesVariant = new SipleFinder();
        var impovisation = new Improvisation();

        var speedometer = new Speedometer(msVariant, OnRaceDone, pacients, receptions);
        speedometer.GoRace();

        speedometer = new Speedometer(siplesVariant, OnRaceDone, pacients, receptions);
        speedometer.GoRace();

        speedometer = new Speedometer(impovisation, OnRaceDone, pacients, receptions);
        speedometer.GoRace();

        Console.Read();
    }

    public static void OnRaceDone(string name, Stopwatch stopwatch, IEnumerable<PacientDataModel> result)
    {
        var count = result?.Count();
        Console.WriteLine($"{name} returns {count} elements.{Environment.NewLine}" +
            $" {stopwatch.ElapsedMilliseconds} ms" +
            $", {stopwatch.ElapsedTicks} ticks");
    }
}