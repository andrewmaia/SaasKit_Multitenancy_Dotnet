using SaasKit.Multitenancy;

namespace SaasKit_Multitenancy
{
    public class AppTenantResolver : ITenantResolver<AppTenant>
    {
        public Task<TenantContext<AppTenant>> ResolveAsync(HttpContext context)
        {
            AppTenant tenant = null;

            if (context.Request.Host.Value.Contains("7029"))
            {
                tenant = new AppTenant { 
                    Name = "TenantProductionRepository",
                    ConnectionString = "Server = *; Database = ProductionRepository; Integrated Security = False; Persist Security Info = False; User ID = *; Password = *; TrustServerCertificate = True; "
                };
            }
            else if (context.Request.Host.Value.Contains("7030"))
            {
                tenant = new AppTenant { 
                    Name = "TenantKeyCloak",
                    ConnectionString = "Server = *; Database = KeyCloak; Integrated Security = False; Persist Security Info = False; User ID = *; Password = *; TrustServerCertificate = True; "
                };
            }

            return Task.FromResult(new TenantContext<AppTenant>(tenant));
        }
    }
}
