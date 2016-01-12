using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Autofac;

namespace RestaurantSearch
{
    public class FindRestaurant
    {
        private string _url;

        public FindRestaurant(String url)
        {
            _url = url;
        }

        public List<Restaurant> WithOutCode(string outcode)
        {
            var httpClient = new HttpClient();
            _url = string.Concat(_url, "restaurants?q=", outcode);

            httpClient.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-GB");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic VGVjaFRlc3RBUEk6dXNlcjI=");
            httpClient.DefaultRequestHeaders.Add("Host", "public.je-apis.com");


            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(_url).Result;
            var contentString = httpResponseMessage.Content.ReadAsStringAsync().Result;

            ContentResponse contentResponse = JsonConvert.DeserializeObject<ContentResponse>(contentString);
            return contentResponse.Restaurants.Count == 0 ? null : contentResponse.Restaurants.Where(c => c.IsOpenNow == true).ToList();
        }
    }
}
