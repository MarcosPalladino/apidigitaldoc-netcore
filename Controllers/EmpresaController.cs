using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using apidigitaldoc.Data;
using apidigitaldoc.Models;

//Endpint => url
//http://localhost:5000/
//https://localhost:5001/
//https://azu...
namespace apidigitaldoc.Controllers
{
    //https://localhost:5001/v1/companies
    [ApiController]
    [Route("v1/companies")]
    public class EmpresaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Empresa>>> Get([FromServices] DataContext context)
        {
            var companies = await context.Empresas.ToListAsync();
            return companies;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Empresa>> Post([FromServices] DataContext context, [FromBody] Empresa model)
        {
            if (ModelState.IsValid)
            {
                context.Empresas.Add(model);
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

