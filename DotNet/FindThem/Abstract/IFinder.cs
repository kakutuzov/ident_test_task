namespace IDENT;

public interface IFinder
{
    IEnumerable<PacientDataModel> GetAllWhoHasRreceptionErlay2017(List<PacientDataModel> pacients
        , List<ReceptionDataModel> receptions);

    string GetName();
}
