using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using apidigitaldoc.Data;
using apidigitaldoc.Models;

namespace apidigitaldoc.Controllers
{
    //https://localhost:5001/v1/companies
    [ApiController]
    [Route("v1/roles")]
    public class PapelController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Papel>>> Get([FromServices] DataContext context)
        {
            var companies = await context.Papeis.ToListAsync();
            return companies;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Papel>> Post([FromServices] DataContext context, [FromBody] Papel model)
        {
            if (ModelState.IsValid)
            {
                context.Papeis.Add(model);
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

