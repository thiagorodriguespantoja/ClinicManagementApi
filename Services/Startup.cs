using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;  // Adicione este namespace
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Este método é chamado pelo runtime. Use este método para adicionar serviços ao contêiner.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddAWSService<IAmazonDynamoDB>();  // Este método agora será reconhecido
        services.AddSingleton<DynamoDbService>();
    }

    // Este método é chamado pelo runtime. Use este método para configurar o pipeline de solicitações HTTP.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
