using Amazon.DynamoDBv2.DataModel;

[DynamoDBTable("Patients")]
public class Patient
{
    [DynamoDBHashKey]
    public int Id { get; set; }

    [DynamoDBProperty]
    public int IdClinica { get; set; }

    [DynamoDBProperty]
    public string Nome { get; set; }

    [DynamoDBProperty]
    public string NomeSocial { get; set; }

    [DynamoDBProperty]
    public string Cpf { get; set; }

    [DynamoDBProperty]
    public string Rg { get; set; }

    [DynamoDBProperty]
    public string Sexo { get; set; }

    [DynamoDBProperty]
    public string Etnia { get; set; }

    [DynamoDBProperty]
    public string Raca { get; set; }

    [DynamoDBProperty]
    public string Naturalidade { get; set; }

    [DynamoDBProperty]
    public string Profissao { get; set; }

    [DynamoDBProperty]
    public string EstadoCivil { get; set; }

    [DynamoDBProperty]
    public string NomePai { get; set; }

    [DynamoDBProperty]
    public string NomeMae { get; set; }

    [DynamoDBProperty]
    public string CpfResponsavel { get; set; }

    [DynamoDBProperty]
    public string NomeConjuge { get; set; }

    [DynamoDBProperty]
    public string ComoConheceu { get; set; }
}
