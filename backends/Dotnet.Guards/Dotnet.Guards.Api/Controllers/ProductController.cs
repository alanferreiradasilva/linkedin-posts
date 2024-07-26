using Dotnet.Guards.Api.Entities;
using Dotnet.Guards.Api.Services;
using GuardNet;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dotnet.Guards.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            Guard.NotNull(service, nameof(service));
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _service.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody, Required]Product model)
        {
            return Ok(await _service.CreateAsync(model));
        }
    }
}
