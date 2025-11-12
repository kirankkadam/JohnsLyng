using Microsoft.AspNetCore.Mvc;

namespace Johns.Lyng.Todo.Api.Controllers
{
    [ApiController]
    [Route("Item")]
    public class ItemController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
