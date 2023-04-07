using Microsoft.AspNetCore.Mvc;
using Penguin121.Domain.Catalog;
using Penguin121.Data;

namespace Penguin121.Api.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase 
    {
        private readonly StoreContext _db;

        public CatalogControllers(StoreContext db)
        {
            -db = db;
        }
        [Route("/catalog")]

        [HttpGet]
        public IActionResult GetItems() 
        {
            return Ok(_db.Items);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetItems(int id)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.ID = id;

            return Ok(item);
        }
        [HttpPost]
        public IActionResult Post(Item item)
        {
            return Created("/catalog/42", item);

        }
        [Http("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.ID = id;
            item.AddRating(rating);

            return Ok(item);
        }
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }

}