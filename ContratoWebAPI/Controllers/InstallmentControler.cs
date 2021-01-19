using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContratoWebAPI.Data;
using ContratoWebAPI.Models;

namespace exercicio.Controllers
{
    [ApiController]
    [Route("v1/contracts")]
    public class InstallmentController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Installment>> GetById([FromServices] DataContext context, int id)
        {
            var Installment = await context.Installments.Include(x => x.Contract).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Installment;
        }

        [HttpGet]
        [Route("contratos/{id:int}")]
        public async Task<ActionResult<List<Installment>>> GetByContrato([FromServices] DataContext context, int id)
        {
            var Installment = await context.Installments.Include(x => x.Contract).AsNoTracking().Where(x => x.ContractId == id).ToListAsync();
            return Installment;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Installment>> Post([FromServices] DataContext context, [FromBody] Installment model)
        {
            if (ModelState.IsValid)
            {
                context.Installments.Add(model);
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