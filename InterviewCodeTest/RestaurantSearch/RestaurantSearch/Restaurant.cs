using System.Collections.Generic;

namespace RestaurantSearch
{
    public class Restaurant
    {
        public string Name  { get; set; }
        public string RatingStars { get; set; }
        public List<CusineType> CuisineTypes { get; set; }
        public bool IsOpenNow { get; set; }
    }
}