﻿using SaasKit.Multitenancy;

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
                    ConnectionString = "Server = SRVDEV01; Database = ProductionRepository; Integrated Security = False; Persist Security Info = False; User ID = billingdev; Password = Talk2012; TrustServerCertificate = True; "
                };
            }
            else // Default Tenant
            {
                tenant = new AppTenant { 
                    Name = "TenantKeyCloak",
                    ConnectionString = "Server = SRVDEV01; Database = KeyCloak; Integrated Security = False; Persist Security Info = False; User ID = billingdev; Password = Talk2012; TrustServerCertificate = True; "
                };
            }

            return Task.FromResult(new TenantContext<AppTenant>(tenant));
        }
    }
}