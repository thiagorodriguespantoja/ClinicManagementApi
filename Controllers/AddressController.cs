using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly DynamoDBContext _context;

    public AddressController(IAmazonDynamoDB dynamoDb)
    {
        _context = new DynamoDBContext(dynamoDb);
    }

    [HttpGet]
    public async Task<IEnumerable<Address>> Get()
    {
        return await _context.ScanAsync<Address>(new List<ScanCondition>()).GetRemainingAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Address address)
    {
        address.Id = new int();  // Generate a new ID
        await _context.SaveAsync(address);
        return Ok(address);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Address address)
    {
        address.Id = id;
        await _context.SaveAsync(address);
        return Ok(address);
    }
}
