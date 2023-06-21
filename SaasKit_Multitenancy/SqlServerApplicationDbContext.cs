using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaasKit_Multitenancy
{
    public class SqlServerApplicationDbContext : DbContext
    {
        private readonly AppTenant _tenant;
        public SqlServerApplicationDbContext(DbContextOptions<SqlServerApplicationDbContext> options, AppTenant tenant) : base(options)
        {
            _tenant = tenant;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_tenant.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
    [Table("Usuario")]
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
    }
}
