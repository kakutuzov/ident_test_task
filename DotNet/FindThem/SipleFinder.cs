namespace IDENT;

internal class SipleFinder : IFinder
{
    public IEnumerable<PacientDataModel> GetAllWhoHasRreceptionErlay2017(List<PacientDataModel> patients
        , List<ReceptionDataModel> receptions)
    {

        var receptonsEarly2017 = receptions.Where(x => x.Date.Year < 2017);
        
        var dictionary = new Dictionary<int, PacientDataModel>();
        foreach(var r in receptonsEarly2017)
        {
            if (dictionary.ContainsKey(r.PatientId))
                continue;

            dictionary.Add(r.PatientId, null);
        }            
        var result = new List<PacientDataModel>(dictionary.Count);
        foreach(var r in patients)
        {
            if (!dictionary.ContainsKey(r.Id))
                continue;

            result.Add(r);
        }
        return result;
    }

    public string GetName()
    {
        return nameof(SipleFinder);
    }
}
