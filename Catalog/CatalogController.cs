using Microsoft.AspNetCore.Mvc;
using Penguin121.Domain.Catalog;

namespace Penguin121.Api.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase {
        [Route("/catalog")]

        [HttpGet]
        public IActionResult GetItems() {
            return Ok("Hello world.");
        }
    }

}