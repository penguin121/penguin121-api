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
            -db == db;
        }
        [Route("/catalog")]

        [HttpGet]
        public IActionResult GetItems() 
        {
            var item= _db.Items.find(id);
            if (item=null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            return Ok(_db.Items.Find(id));

        }
        [HttpPost]
        public IActionResult Post(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.id}", item);

        }
        [Http("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item= _db.Items.Find(id);
            if (item==null)
            { 
                return NotFound();
            }
        
            item.AddRating(rating);
            _db.SaveChanges();

            return Ok(item);
        }
        [HttpPut("{id:int}")]
        public IActionResult PutItem(int id,[FromBody] Item item)
        {
            if(id =! item.ID){
            return BadRequest();
        }
        if (_db.Items.Find(id)== null)
        {
            return NotFound();
        }
        _db.Entry(item).State= EntityState.Modified;
        _db.SaveChanges();

        return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var item = _db.Items.Find(id);
            if(item==null)
            {
                return NotFound();
            }
            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok();
        }
    }
}