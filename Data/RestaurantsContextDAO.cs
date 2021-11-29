using System.Collections.Generic;
using FinalProject_CompProg.Interfaces;
using FinalProject_CompProg.Models;
using System.Linq;
using System;

namespace FinalProject_CompProg.Data
{
    public class RestaurantsContextDAO : IRestaurantsContextDAO
    {
        private RestaurantsContext _context;
        public RestaurantsContextDAO(RestaurantsContext context)
        {
            _context = context;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetById(int id)
        {
            return _context.Restaurants.Where(x => x.id.Equals(id));
        }
        public int? RemoveRestaurantById(int id)
        {
            Restaurant restaurant = this.GetById(id);
            if(restaurant != null)
            {
                try
                {
                    _context.Restaurants.Remove(restaurant);
                    _context.SaveChanges();
                    return 1;
                }
                catch(Exception)
                {
                    return 0;
                }
            }
            return null;
        }

        public int? UpdateRestaurant (Restaurant restaurant)
        {
            Restaurant restaurantToUpdate = this.GetById(restaurant.id);
            if(restaurrestaurantToUpdateant == null) 
            {
                return null;
            }

            try
            {
                restaurantToUpdate.name = restaurant.name;
                restaurantToUpdate.foodType = restaurant.foodType;
                restaurantToUpdate.founder = restaurant.founder;
                restaurantToUpdate.foundingYear = restaurant.foundingYear;

                _context.Restaurants.Update(restaurantToUpdate);
                _context.SaveChanges();
                return 1;
            } 
            catch(Exception)
            {
                return 0;
            }   
        }

        public int? Add(Restaurant restaurant)
        {
            Restaurant restaurantWithSameID = _context.Restaurants.Where(x => x.id.Equals(restaurant.id));

            if(restaurantWithSameID != null)
            {
                return null;
            }

            try
            {
                _context.Restaurants.Add(restaurant);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }
    }
}
