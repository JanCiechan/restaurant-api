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

    }
}
