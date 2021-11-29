using System.Collections.Generic;
using FinalProject_CompProg.Models;

namespace FinalProject_CompProg.Interfaces
{
    public interface IRestaurantsContextDAO
    {
        List<Restaurant> GetAllRestaurants();
        Restaurant GetById(int id);
        int? RemoveRestaurantById(int id);
        int? UpdateRestaurant (Restaurant restaurant);
        int? Add(Restaurant restaurant);
    }
}