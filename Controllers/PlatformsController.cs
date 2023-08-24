using RedisApi.Data;
using RedisApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace RedisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IConfiguration _conf;

        public PlatformsController(IPlatformRepo repository, IConfiguration conf)
        {
            _repository = repository;
            _conf = conf;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetPlatforms()
        {
            return Ok(_repository.GetAllPlatforms());
        }

        [HttpGet("{id}", Name="GetPlatformById")]
        public ActionResult<IEnumerable<Platform>> GetPlatformById(string id)
        {
            
            var platform = _repository.GetPlatformById(id);
            
            if (platform != null)
            {
                return Ok(platform);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult <Platform> CreatePlatform(Platform platform)
        {
            _repository.CreatePlatform(platform);

            return CreatedAtRoute(nameof(GetPlatformById), new {Id = platform.Id}, platform);
        }
    }
}
