using System.ComponentModel.DataAnnotations;

namespace RestaurantApi
{
    public class Food
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Price { get; set; }
        public bool Vegan { get; set; }


    }
}
