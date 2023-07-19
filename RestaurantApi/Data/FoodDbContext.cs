﻿using Microsoft.EntityFrameworkCore;

namespace RestaurantApi.Data
{
    public class FoodDbContext:DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {

        }
        public DbSet<Food> Foods { get; set; }
    }
}
