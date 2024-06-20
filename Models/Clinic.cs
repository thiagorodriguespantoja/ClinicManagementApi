using Amazon.DynamoDBv2.DataModel;

[DynamoDBTable("Clinics")]
public class Clinic
{
    public Clinic()
    {
        NomeConsultorio = string.Empty;  // Inicializando a propriedade no construtor
    }

    [DynamoDBHashKey]
    public int Id { get; set; }

    [DynamoDBProperty]
    public string NomeConsultorio { get; set; }
}
