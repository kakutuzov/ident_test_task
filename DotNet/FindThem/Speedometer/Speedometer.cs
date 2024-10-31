using System.Diagnostics;

namespace IDENT;

public class Speedometer
{
    public event Action<string, Stopwatch, IEnumerable<PacientDataModel>> OnRaceDoneEvent;

    protected readonly IFinder Racer;
    protected readonly List<ReceptionDataModel> Receptions;
    protected readonly List<PacientDataModel> Pacients;

    public Speedometer(IFinder finder
        , Action<string, Stopwatch, IEnumerable<PacientDataModel>> onRaceDone
        , List<PacientDataModel> pacients
        , List<ReceptionDataModel> receptions)
    {
        Racer = finder ?? throw new ArgumentNullException(nameof(finder));
        Receptions = receptions ?? throw new ArgumentNullException(nameof(receptions));
        Pacients = pacients ?? throw new ArgumentNullException(nameof(pacients));

        OnRaceDoneEvent = onRaceDone;
    }

    public void GoRace()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var result = Racer.GetAllWhoHasRreceptionErlay2017(Pacients, Receptions);
        stopWatch.Stop();
        OnRaceDoneEvent?.Invoke(Racer.GetName(), stopWatch, result);
    }

}
