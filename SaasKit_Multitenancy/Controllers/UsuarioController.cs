using Microsoft.AspNetCore.Mvc;

namespace SaasKit_Multitenancy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly SqlServerApplicationDbContext _context;

        public UsuarioController(SqlServerApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> Get()
        {
            return _context.Usuarios;
        }
    }
}