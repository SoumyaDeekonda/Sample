using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestaurantSearch;

namespace RestaurantSearchWeb
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Find_Click(object sender, EventArgs e)
        {
            RestaurantView.EmptyDataText = "No data available.";
            string searchText = this.@where.Text;
            string BaseURI = ConfigurationManager.AppSettings["BaseURL"];
            FindRestaurant findRestaurant = new FindRestaurant(BaseURI);
            try
            {
                List<Restaurant> restaurants = findRestaurant.WithOutCode(searchText);
                RestaurantView.DataSource = restaurants;
                RestaurantView.DataBind();
            }
            catch (Exception)
            {
                RestaurantView.EmptyDataText = "Something got a bit wrong Please try again later";
                RestaurantView.DataBind();
            }

        }
    }
}