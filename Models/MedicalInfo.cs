using Amazon.DynamoDBv2.DataModel;

[DynamoDBTable("InformacoesMedicas")]
public class MedicalInfo
{
    [DynamoDBHashKey]
    public int Id { get; set; }

    [DynamoDBProperty]
    public int IdPaciente { get; set; }

    [DynamoDBProperty]
    public string TipoSanguineo { get; set; }

    [DynamoDBProperty]
    public decimal Peso { get; set; }

    [DynamoDBProperty]
    public decimal Altura { get; set; }

    [DynamoDBProperty]
    public decimal IMC { get; set; }

    [DynamoDBProperty]
    public string Alergia { get; set; }
}
