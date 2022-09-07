using Microsoft.EntityFrameworkCore;
using Netto.Public.DataContext;
using Netto.Public.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Netto.Public.API.Extensions;
using Netto.Public.API.Options;
using Netto.Public.Application.Extensions;
using Netto.Public.DataContext.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionsFilter(builder.Configuration);
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.Override.json",
                       optional: true,
                       reloadOnChange: true);
});

builder.Services.Configure<ExchangeRatesOptions>(builder.Configuration.GetSection("ExchangeRates"));

builder.Services.Configure<ExchangeRateSiteProperties>(builder.Configuration.GetSection("ExchangeRateSiteProperties"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllersExtension();

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

var versionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (!app.Environment.IsProduction())
{
    app.UseSwagger(c => { c.SerializeAsV2 = true; });
    app.UseSwaggerUI(options =>
    {
        foreach (ApiVersionDescription description in versionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Netto_New_Public {description.GroupName}");
        }
    });
}

app.UseHttpsRedirection();

app.UseCustomCorsExtension();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PublicDbContext>();
    db.Database.Migrate();
}

app.Run();
