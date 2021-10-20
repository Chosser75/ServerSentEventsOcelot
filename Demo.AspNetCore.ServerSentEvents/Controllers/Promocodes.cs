﻿using Demo.AspNetCore.ServerSentEvents.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.AspNetCore.ServerSentEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Promocodes : ControllerBase
    {
        private readonly IPromocodeService _promocodeService;

        public Promocodes(IPromocodeService promocodeService)
        {
            _promocodeService = promocodeService;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CancelPromocode(string id)
        {
            var response = await _promocodeService.CancelPromocodeAsync(id);

            return Ok(response);
        }
    }
}
