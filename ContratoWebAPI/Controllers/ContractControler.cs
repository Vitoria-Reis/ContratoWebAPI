using System;
using Microsoft.AspNetCore.Mvc;
using ContratoWebAPI.Data;
using ContratoWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

namespace ContratoWebAPI.Controllers
{
    [ApiController]
    [Route("v1/contracts")]
    public class ContractController : ControllerBase
    {
        private IFeatureManager _featureManager;
        public ContractController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Contract>>> Contrato(
            [FromServices] DataContext context, [FromServices] IMemoryCache _cache, [FromServices] IConfiguration _config)
        {
            float cacheExpiration = float.Parse(_config.GetSection("Settings").GetSection("CacheExpirationTimeSeconds").Value);
            if (await _featureManager.IsEnabledAsync("FeatureCache"))
            {
                var cacheEntry = await _cache.GetOrCreate(context, async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
                    entry.SetPriority(CacheItemPriority.High);
                    return await Contrato(context);
                });
                return cacheEntry;
            }
            else return await Contrato(context);
        }
        private async Task<ActionResult<List<Contract>>> Contrato([FromServices] DataContext context)
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