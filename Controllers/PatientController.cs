using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly DynamoDBContext _context;

    public PatientController(IAmazonDynamoDB dynamoDb)
    {
        _context = new DynamoDBContext(dynamoDb);
    }

    [HttpGet]
    public async Task<IEnumerable<Patient>> Get()
    {
        return await _context.ScanAsync<Patient>(new List<ScanCondition>()).GetRemainingAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Patient patient)
    {
        patient.Id = new int();  // Generate a new ID
        await _context.SaveAsync(patient);
        return Ok(patient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Patient patient)
    {
        patient.Id = id;
        await _context.SaveAsync(patient);
        return Ok(patient);
    }
}
