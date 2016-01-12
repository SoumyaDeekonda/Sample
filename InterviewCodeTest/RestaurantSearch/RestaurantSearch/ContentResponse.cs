using System.Collections.Generic;

namespace RestaurantSearch
{
    public class ContentResponse
    {
        public string ShortResultText { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}