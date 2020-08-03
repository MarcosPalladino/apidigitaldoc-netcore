using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using apidigitaldoc.Data;
using apidigitaldoc.Models;
using System.Linq;

//Endpint => url
//http://localhost:5000/
//https://localhost:5001/
//https://azu...
namespace apidigitaldoc.Controllers
{
    //https://localhost:5001/v1/users
    [ApiController]
    [Route("v1/users")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Usuario>>> Get([FromServices] DataContext context)
        {
              List<Usuario> users = null;
            users = await context.Usuarios.Include(x => x.Empresa)
            .AsNoTracking()
            .ToListAsync();

            return users;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Usuario>> Get([FromServices] DataContext context, int id)
        {
            var user = await context.Usuarios.Include(x => x.Empresa)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.id == id);
            return user;
        }

        [HttpGet]
        [Route("/{q:alpha}")]
        public async  Task<ActionResult<List<Usuario>>>  Get([FromQuery] DataContext context, string q)
        {
            var user = await context.Usuarios.Include(x => x.Empresa)
            .AsNoTracking()
            .Where( r => r.NomeCompleto.StartsWith(q)) 
            .ToListAsync();
            return user;
        }

        [HttpGet]
        [Route("companies/{id:int}")]
        public async Task<ActionResult<List<Usuario>>> GetByEmpresa([FromServices] DataContext context, int id)
        {
            List<Usuario> users = null;
            users = await context.Usuarios.Include(x => x.Empresa).AsNoTracking()
                        .Where(c => c.EmpresaId == id).ToListAsync();

            return users;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Usuario>> Post([FromServices] DataContext context, [FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                context.Usuarios.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}

