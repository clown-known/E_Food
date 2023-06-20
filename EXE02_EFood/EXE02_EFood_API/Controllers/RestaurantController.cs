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

        [HttpGet("/api/restaurant/review")]
        public IActionResult ReviewOfRes()
        {
            List<ReviewOfResApiModel> result = new List<ReviewOfResApiModel>();
            List<ReviewOfRe> reviewsOfRes = _reviewOfResRepo.GetAll();
            if(reviewsOfRes != null && reviewsOfRes.Count > 0)
            {
                foreach (ReviewOfRe item in reviewsOfRes)
                {
                    result.Add(new ReviewOfResApiModel { ReviewId = item.ReviewId, RestaurantName = item.Res.Name, Comment = item.Comment, Time = item.Time.Value.ToString(), UserFullName = item.User.Name, Voting = item.Voting });
                }
                return Ok(result);
            }
            
            return NoContent();
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
