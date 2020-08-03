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
    [Route("v1/documents")]
    public class DocumentoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Documento>>> Get([FromServices] DataContext context)
        {
              List<Documento> users = null;
            users = await context.Documentos.Include(x => x.Usuario)
            .AsNoTracking()
            .ToListAsync();

            return users;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Documento>> Get([FromServices] DataContext context, int id)
        {
            var user = await context.Documentos.Include(x => x.Usuario)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.id == id);
            return user;
        }

        [HttpGet]
        [Route("fromuser/{id:int}")]
        public async Task<ActionResult<List<Documento>>> GetByEmpresa([FromServices] DataContext context, int id)
        {
            List<Documento> users = null;
            users = await context.Documentos.Include(x => x.Usuario).AsNoTracking()
                        .Where(c => c.UsuarioId == id).ToListAsync();

            return users;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Documento>> Post([FromServices] DataContext context, [FromBody] Documento model)
        {
            if (ModelState.IsValid)
            {
                context.Documentos.Add(model);
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

