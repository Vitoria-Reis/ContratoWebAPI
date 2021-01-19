using Microsoft.AspNetCore.Mvc;
using ContratoWebAPI.Data;
using ContratoWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContratoWebAPI.Controllers
{
    [ApiController]
    [Route("v1/contracts")]
    public class ContractController : ControllerBase
    {
        private DataContext _context;
        
        public ContractController(DataContext context) {
        _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Contract>>> Get([FromServices] DataContext context)
        {
            var contracts = await context.Contracts.ToListAsync();
            return contracts;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Contract>> Post([FromServices] DataContext context, [FromBody] Contract model)
        {
            if (ModelState.IsValid)
            {
                context.Contracts.Add(model);
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