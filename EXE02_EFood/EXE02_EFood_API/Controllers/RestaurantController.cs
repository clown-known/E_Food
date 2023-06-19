using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using AutoMapper;
using EXE02_EFood_API.ApiModels;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantController(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            var restaurants = _restaurantRepository.GetAll();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public IActionResult GetRestaurant(int id)
        {
            var restaurant = _restaurantRepository.Get(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult CreateRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.Create(restaurant);
            return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.ResId }, restaurant);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant(int id, Restaurant restaurant)
        {
            var existingRestaurant = _restaurantRepository.Get(id);
            if (existingRestaurant == null)
            {
                return NotFound();
            }

            existingRestaurant.Name = restaurant.Name;
            existingRestaurant.Address = restaurant.Address;
            // Tiếp tục ánh xạ các thuộc tính khác của restaurant vào existingRestaurant

            _restaurantRepository.Update(existingRestaurant);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            var restaurant = _restaurantRepository.Get(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _restaurantRepository.Delete(id);

            return NoContent();
        }
    }
}
