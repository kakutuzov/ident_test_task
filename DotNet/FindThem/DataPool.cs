namespace IDENT;

public class ReceptionDataModel
{
    public int PatientId { get; set; }
    public DateTime Date { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is ReceptionDataModel receptionData)
            return receptionData.PatientId == PatientId;

        return false;
    }

    public override int GetHashCode()
    {
        return PatientId.GetHashCode();
    }
}

public class PacientDataModel 
{
    public int Id { get; set; }
    public string Surname { get; set; } = String.Empty;

    public override bool Equals(object? obj)
    {
        if (obj is PacientDataModel pacient)
            return pacient.Id == Id;

        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

internal class DataPool
{
    public static List<ReceptionDataModel> GenerateReceptionData() 
    {
        var rand = new Random();
        var receptions = Enumerable.Range(1, 500000)
            .SelectMany(pid => Enumerable.Range(1, rand.Next(0, 100))
            .Select(rid => new ReceptionDataModel() {
                PatientId = pid,
                Date = new DateTime(2017, 06, 30).AddDays(-rand.Next(1, 500))
            }))
            .ToList();

        return receptions;
    }

    public static List<PacientDataModel> GeneratePacientData()
    {
        var patients = Enumerable.Range(1, 500000)
            .Select(pid => new PacientDataModel()
            {
                Id = pid,
                Surname = string.Format("Иванов{0}", pid)
            })
            .ToList();

        return patients;
    }
    
}
