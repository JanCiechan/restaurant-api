using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Data;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly FoodDbContext _foodDbContext;
        public FoodController(FoodDbContext context) => _foodDbContext = context;
        [HttpGet]
        public async Task<IEnumerable<Food>> Get()
        {
            return await _foodDbContext.Foods.ToListAsync();
        }
        [HttpGet("id")]
        [ProducesResponseType(typeof(Food), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var food = await _foodDbContext.Foods.FindAsync(id);
            return food == null ? NotFound() : Ok(food);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create(Food food)
        {
            await _foodDbContext.Foods.AddAsync(food);
            await _foodDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = food.Id }, food);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(int id,Food food)
        {
            if(id!= food.Id) return BadRequest();
            _foodDbContext.Entry(food).State = EntityState.Modified;
            await _foodDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int id)
        {
            var foodToDelete= await _foodDbContext.Foods.FindAsync(id);
            if (foodToDelete == null) return NotFound();
            _foodDbContext.Foods.Remove(foodToDelete);
            await _foodDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
