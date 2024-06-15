using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NetCore.CachingDemo.Api.Models.Continents;
using NetCore.CachingDemo.Api.Seed;

namespace NetCore.CachingDemo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContinentsController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private const string CONTINENT_KEY = "CONTINENTS";

        public ContinentsController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = new List<ContinentResponseModel>();

            if (!_memoryCache.TryGetValue(CONTINENT_KEY, out entities))
            {
                entities = ContinentSeed.GetAllContinents();

                _memoryCache.Set(CONTINENT_KEY, entities);
            }

            return Ok(entities);
        }
    }
}
