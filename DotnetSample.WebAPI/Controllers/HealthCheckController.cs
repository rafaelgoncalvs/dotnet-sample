using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace DotnetSample.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheckController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public HealthCheckController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<string> Get()
    {
        var date = await GetCurrentDate();
        return "Healthy";
    }

    private async Task<DateTime> GetCurrentDate()
    {
        var connectionString = _configuration.GetConnectionString("DotnetSample");

        var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        DateTime date = default;
        await using var cmd = new NpgsqlCommand("SELECT now()", connection);
        await using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            date = reader.GetDateTime(0);
        }
        return date;
    }
}

public class HealthCheckDto
{
    public DateTime Date { get; set;  }
}
