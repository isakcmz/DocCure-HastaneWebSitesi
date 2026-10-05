using Doccure.MarketService.Services.RedisServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Doccure.MarketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaTestController : ControllerBase
    {
        private readonly IRedisService _redisService;

        public AreaTestController(IRedisService redisService)
        {
            _redisService = redisService;
        }

        
    }
}
