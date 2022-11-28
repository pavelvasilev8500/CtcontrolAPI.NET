using CtcontrolAPIService.Models;
using CtcontrolAPIService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CtcontrolAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusDataController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public StatusDataController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<StatusDataModel>> Get()
        {
            return await _mongoDBService.StatusGetAsync();
        }

        [HttpGet("{id}")]
        public async Task<StatusDataModel> Get(string id)
        {
            return await _mongoDBService.StatusGetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StatusDataModel statusDataModel)
        {
            await _mongoDBService.StatusCreateAsync(statusDataModel);
            if (!_mongoDBService._issuccess)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = statusDataModel.Id }, statusDataModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, StatusDataModel statusDataModel)
        {
            await _mongoDBService.StatusUpdateAsync(id, statusDataModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDBService.StatusDeleteAsync(id);
            return NoContent();
        }

    }
}
