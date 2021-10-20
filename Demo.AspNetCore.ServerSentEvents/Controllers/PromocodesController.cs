using Demo.AspNetCore.ServerSentEvents.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Demo.AspNetCore.ServerSentEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocodesController : ControllerBase
    {
        private readonly IPromocodeService _promocodeService;

        public PromocodesController(IPromocodeService promocodeService)
        {
            _promocodeService = promocodeService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CancelPromocode(string id)
        {
            var response = await _promocodeService.CancelPromocodeAsync(id);

            return Ok(response);
        }
    }
}
