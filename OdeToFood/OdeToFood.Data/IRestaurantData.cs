using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        // IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Ganda Kachra", Location = "Delhi", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 2, Name = "Pasta DeNiro", Location = "Andolini", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 3, Name = "Narcos Guapos", Location = "Guadalajara", Cuisine = CuisineType.Mexican }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            //return restaurants;
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
            /*
            return from r in restaurants
                   orderby r.Name
                   select r;
            */
        }
    }
}
