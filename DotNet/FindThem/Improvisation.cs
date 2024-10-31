namespace IDENT;

internal class Improvisation : IFinder
{
    public IEnumerable<PacientDataModel> GetAllWhoHasRreceptionErlay2017(List<PacientDataModel> pacients
        , List<ReceptionDataModel> receptions)
    {
        var targetReceptions = receptions
            .Where(x => x.Date.Year < 2017)
            .Select(x => new PacientDataModel() { Id = x.PatientId })
            .ToHashSet();
        var result = pacients.Where(x => targetReceptions.Contains(x));
        return result;
    }

    public string GetName()
    {
        return nameof(Improvisation);
    }
}
