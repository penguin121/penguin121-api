using Microsoft.AspNetCore.Mvc;
using Penguin121.Domain.Catalog;

namespace Penguin121.Api.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase 
    {
        [Route("/catalog")]

        [HttpGet]
        
        public IActionResult GetItems() 
        {
            var items = new List<Item>()
            {
                new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m),
                new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m),
            };
            
            return Ok("items");
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