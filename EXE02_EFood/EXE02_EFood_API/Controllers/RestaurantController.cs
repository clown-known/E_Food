﻿using System;
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

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IReviewOfResRepo _reviewOfResRepo;

        public RestaurantController(IRestaurantRepository restaurantRepository, IMapper mapper, IReviewOfResRepo reviewOfResRepo, IUserRepository userRepository)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
            _reviewOfResRepo = reviewOfResRepo;
            _userRepository = userRepository;

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

        private bool RestaurantExists(int id)
        {
            var restaurant = _restaurantRepository.Get(id);
            return restaurant != null;
        }

        [HttpGet("/api/restaurant/review")]
        public IActionResult ReviewOfRes()
        {
            List<ReviewOfResApiModel> result = new List<ReviewOfResApiModel>();
            foreach (ReviewOfRe item in _reviewOfResRepo.GetAll())
            {
                result.Add(new ReviewOfResApiModel { ReviewId = item.ReviewId, RestaurantName = item.Res.Name, Comment = item.Comment, Time = item.Time.Value.ToString(), UserFullName = item.User.Name, Voting = item.Voting });
            }
            return Ok(result);
        }
        [HttpGet("/api/restaurant/review/{resId}")]
        public IActionResult GetReviewResById(int? resId)
        {
            if (resId == null)
            {
                return NotFound();
            }
            var reviewReses = _reviewOfResRepo.GetReviewResById((int)resId);
            if (reviewReses.Count == 0)
            {
                return NotFound();
            }
            List<ReviewOfResApiModel> results = new List<ReviewOfResApiModel>();
            foreach (var item in reviewReses)
            {
                results.Add(new ReviewOfResApiModel { ReviewId = item.ReviewId, RestaurantName = item.Res.Name, Comment = item.Comment, Time = item.Time.Value.ToString(), UserFullName = item.User.Name, Voting = item.Voting });
            }

            return Ok(results);
        }

        [HttpPost("/api/restaurant/review")]
        public IActionResult CreateReviewResById([FromBody] ReviewRequestModel model)
        {
            var lastReview = _reviewOfResRepo.GetLastReview();
            var user = _userRepository.Get(model.UserId);
            var restaurant = _restaurantRepository.Get((int)model.ResId);
            ReviewOfRe review = new ReviewOfRe();
            review.ReviewId = lastReview.ReviewId + 1;
            review.UserId = model.UserId;
            review.ResId = model.ResId;
            review.User = user;
            review.Res = restaurant;
            review.Comment = model.ReviewContent;
            review.Voting = model.Voting;
            review.Time = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString());
            review.Status = 1;
            review.IsDeleted = false;
            
            var res = _reviewOfResRepo.Create(review);
            ReviewOfResApiModel result = new ReviewOfResApiModel();
            result.ReviewId = res.ReviewId;
            result.UserFullName = res.User.Name;
            result.Comment = res.Comment;
            result.Time = res.Time.ToString();
            result.RestaurantName = res.Res.Name;
            result.Voting = res.Voting;
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("/api/restaurant/review/{id}")]
        public IActionResult UpdateReviewResById(int id, [FromBody] ReviewRequestModel model)
        {
            var user = _userRepository.Get(model.UserId);
            var restaurant = _restaurantRepository.Get((int)model.ResId);
            ReviewOfRe review = new ReviewOfRe();
            review.UserId = model.UserId;
            review.ResId = model.ResId;
            review.User = user;
            review.Res = restaurant;
            review.Comment = model.ReviewContent;
            review.Voting = model.Voting;
            review.Time = TimeSpan.Parse(DateTime.Now.Hour.ToString());
            review.Status = 1;
            review.IsDeleted = false;
            _reviewOfResRepo.Update(id, review);
            return Ok(model);
        }

        [HttpDelete("/api/restaurant/review/{id}")]
        public IActionResult DeleteReviewResById(int id)
        {
            _reviewOfResRepo.Delete(id);
            return Ok();
        }
    }
}
