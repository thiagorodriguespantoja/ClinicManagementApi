using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class MedicalInfoController : ControllerBase
{
    private readonly DynamoDBContext _context;

    public MedicalInfoController(IAmazonDynamoDB dynamoDb)
    {
        _context = new DynamoDBContext(dynamoDb);
    }

    [HttpGet]
    public async Task<IEnumerable<MedicalInfo>> Get()
    {
        return await _context.ScanAsync<MedicalInfo>(new List<ScanCondition>()).GetRemainingAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MedicalInfo medicalInfo)
    {
        medicalInfo.Id = new int();  // Generate a new ID
        await _context.SaveAsync(medicalInfo);
        return Ok(medicalInfo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] MedicalInfo medicalInfo)
    {
        medicalInfo.Id = id;
        await _context.SaveAsync(medicalInfo);
        return Ok(medicalInfo);
    }
}
