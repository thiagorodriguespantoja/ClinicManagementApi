using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ClinicController : ControllerBase
{
    private readonly IDynamoDBContext _context;

    public ClinicController(IAmazonDynamoDB dynamoDb)
    {
        _context = new DynamoDBContext(dynamoDb);
    }

    [HttpGet]
    public async Task<IEnumerable<Clinic>> Get()
    {
        return await _context.ScanAsync<Clinic>(new List<ScanCondition>()).GetRemainingAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Clinic clinic)
    {
        // Gerar um novo ID para a clínica. 
        // Você pode usar um Guid ou uma lógica específica para seu contexto.
        clinic.Id = new Random().Next(1, 100000);  // Exemplo simples usando Random. Use uma abordagem melhor para produção.
        await _context.SaveAsync(clinic);
        return Ok(clinic);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Clinic clinic)
    {
        clinic.Id = id;
        await _context.SaveAsync(clinic);
        return Ok(clinic);
    }
}
