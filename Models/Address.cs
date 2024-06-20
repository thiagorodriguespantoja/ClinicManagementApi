using Amazon.DynamoDBv2.DataModel;

[DynamoDBTable("EnderecoPaciente")]
public class Address
{
    [DynamoDBHashKey]
    public int Id { get; set; }

    [DynamoDBProperty]
    public int IdPaciente { get; set; }

    [DynamoDBProperty]
    public string? Cep { get; set; }  // Tornando a propriedade anulável

    [DynamoDBProperty]
    public string? Endereco { get; set; }

    [DynamoDBProperty]
    public string? Numero { get; set; }

    [DynamoDBProperty]
    public string? Complemento { get; set; }

    [DynamoDBProperty]
    public string? Bairro { get; set; }

    [DynamoDBProperty]
    public string? Cidade { get; set; }

    [DynamoDBProperty]
    public string? Estado { get; set; }
}

