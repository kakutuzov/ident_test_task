namespace IDENT;

internal class MSTraditionFinder : IFinder
{
    public IEnumerable<PacientDataModel> GetAllWhoHasRreceptionErlay2017(List<PacientDataModel> pacients
        , List<ReceptionDataModel> receptions)
    {
        var target = receptions.Where(x => x.Date.Year < 2017)
            .Select(x => new PacientDataModel{ Id = x.PatientId})
            .Distinct();

        var result = pacients.Intersect(target);

        return result;
    }

    public string GetName()
    {
        return nameof(MSTraditionFinder);
    }
}
