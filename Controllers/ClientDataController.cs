using CtcontrolAPIService.Models;
using CtcontrolAPIService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CtcontrolAPIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientDataController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public ClientDataController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<ClientDataModel>> Get()
        {
            return await _mongoDBService.ClientGetAsync();
        }

        [HttpGet("{id}")]
        public async Task<ClientDataModel> Get(string id)
        {
            return await _mongoDBService.ClientGetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientDataModel clientDataModel)
        {
            await _mongoDBService.ClientCreateAsync(clientDataModel);
            if (!_mongoDBService._issuccess)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new {id = clientDataModel.Id}, clientDataModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ClientDataModel clientDataModel)
        {
            await _mongoDBService.ClientUpdateAsync(id, clientDataModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDBService.ClientDeleteAsync(id);
            return NoContent();
        }
    }
}
