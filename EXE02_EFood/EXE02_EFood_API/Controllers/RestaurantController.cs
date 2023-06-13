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
        private readonly IMapper _mapper;

        public RestaurantController(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        // GET: api/Restaurant
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            return _restaurantRepository.GetAll();
        }

        // GET: api/Restaurant/5
        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get(int id)
        {
            var restaurant =  _restaurantRepository.Get(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // PUT: api/Restaurant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult UpdateRestaurant(int id, RestaurantApiModel restaurantDto)
        {
            var existingRestaurant = _restaurantRepository.Get(id);

            if (existingRestaurant == null)
            {
                return NotFound();
            }

            // Ánh xạ dữ liệu từ restaurantDto vào existingRestaurant
            _mapper.Map(restaurantDto, existingRestaurant);

            _restaurantRepository.Update(existingRestaurant);

            return Ok(existingRestaurant);
        }

        // POST: api/Restaurant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostRestaurant(RestaurantApiModel restaurant)
        {
            var res = _mapper.Map<Restaurant>(restaurant);
            _restaurantRepository.Create(res);
            return CreatedAtAction(nameof(Get), new { id = res.ResId}, res);
        }

        // DELETE: api/Restaurant/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            var restaurant =  _restaurantRepository.Get(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _restaurantRepository.Delete(id);

            return NoContent();
        }

        private bool RestaurantExists(int id)
        {
            var restaurant = _restaurantRepository.Get(id);
            return restaurant != null;
        }
    }
}
