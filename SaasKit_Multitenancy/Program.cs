using SaasKit_Multitenancy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMultitenancy<AppTenant, AppTenantResolver>();
builder.Services.AddDbContext<SqlServerApplicationDbContext>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseMultitenancy<AppTenant>();

app.UseAuthorization();

app.MapControllers();

app.Run();
