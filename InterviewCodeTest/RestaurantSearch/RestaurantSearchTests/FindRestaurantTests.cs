using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSearch;

namespace RestaurantSearchTests
{
    [TestClass]
    public class FindRestaurantTests
    {
        [TestMethod]
        public void WhenSearchingForRestaurantWith_SE19_ShouldReturnRestaurant()
        {
            string BaseURI = "https://public.je-apis.com/";
            FindRestaurant findRestaurant = new FindRestaurant(BaseURI);
            var restaurant = findRestaurant.WithOutCode("SE19");
            Assert.IsNotNull(restaurant);
        }

        [TestMethod]
        public void WhenSearchingForRestaurantWith_BLANK_ShouldReturn_Null()
        {
            string BaseURI = "https://public.je-apis.com/";
            FindRestaurant findRestaurant = new FindRestaurant(BaseURI);
            var restaurant = findRestaurant.WithOutCode("");
            Assert.IsNull(restaurant);
        }

        [TestMethod]
        public void WhenSearchingForRestaurantWith_SE19_ShouldReturn_Rating()
        {
            string BaseURI = "https://public.je-apis.com/";
            FindRestaurant findRestaurant = new FindRestaurant(BaseURI);
            var restaurant = findRestaurant.WithOutCode("SE19");
            Assert.IsNotNull(restaurant[0].RatingStars);
        }

        [TestMethod]
        public void WhenSearchingForRestaurantWith_SE19_ShouldReturn_FoodType()
        {
            string BaseURI = "https://public.je-apis.com/";
            FindRestaurant findRestaurant = new FindRestaurant(BaseURI);
            var restaurant = findRestaurant.WithOutCode("SE19");
            Assert.IsNotNull(restaurant[0].CuisineTypes[0].Name);
        }

        [TestMethod]
        public void WhenSearchingForRestaurantWith_SE19_ShouldReturnRestaurantWhichAreAvailable()
        {
            string BaseURI = "https://public.je-apis.com/";
            FindRestaurant findRestaurant = new FindRestaurant(BaseURI);
            var restaurant = findRestaurant.WithOutCode("SE19");
            bool any = restaurant.Any(c => c.IsOpenNow == false);
            Assert.IsFalse(any);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void WhenSearchingForRestaurantWith_SE19_ShouldThrowExcptionWhenExternalURLIsDown()
        {
            string BaseURI = "https://blah/";
            FindRestaurant findRestaurant = new FindRestaurant(BaseURI);
            var restaurant = findRestaurant.WithOutCode("SE19");
            bool any = restaurant.Any(c => c.IsOpenNow == false);
        }
    }
}
