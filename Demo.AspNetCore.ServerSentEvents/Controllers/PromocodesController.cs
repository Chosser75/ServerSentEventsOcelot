using Demo.AspNetCore.ServerSentEvents.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading;
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

        [HttpPut("{id}/{requestId}")]
        public IActionResult CancelPromocode(string id, string requestId)
        {
            Thread t = new Thread( async () =>
            {
                await _promocodeService.CancelPromocodeAsync(id, requestId);
            });
            t.IsBackground = false;
            t.Start();
            

            return Ok($"Запрос {requestId} на отмену промокода {id} принят. Дождитесь ответа.");
        }
    }
}
