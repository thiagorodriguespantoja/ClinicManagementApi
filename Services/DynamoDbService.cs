using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

public class DynamoDbService
{
    private readonly IDynamoDBContext _context;

    public DynamoDbService(IAmazonDynamoDB dynamoDb)
    {
        _context = new DynamoDBContext(dynamoDb);
    }

    // Métodos para operações com o DynamoDB
}
