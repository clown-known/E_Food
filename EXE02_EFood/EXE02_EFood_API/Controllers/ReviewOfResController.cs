using EXE02_EFood_API.ApiModels;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewOfResController : ControllerBase
    {
        private readonly IReviewOfResRepo reviewOfResRepo;

        public ReviewOfResController(IReviewOfResRepo reviewOfResRepo)
        {
            this.reviewOfResRepo = reviewOfResRepo;

        }
        [HttpGet]
        public IActionResult ReviewOfRes()
        {
            List< ReviewOfResApiModel> result = new List<ReviewOfResApiModel>();
            foreach (ReviewOfRe item in reviewOfResRepo.GetAll())
            {
                result.Add(new ReviewOfResApiModel { ReviewId = item.ReviewId, RestaurantName = item.Res.Name, Comment = item.Comment, Time = item.Time.Value.ToString(), UserFullName = item.User.Name, Voting = item.Voting });
            }
            return Ok(result); 
        }
        [HttpGet ("{resId}")]
        public IActionResult GetReviewResById(int? resId)
        {
            if(resId == null)
            {
                return NotFound();
            }
            var reviewReses = reviewOfResRepo.GetReviewResById((int)resId);
            if(reviewReses.Count == 0)
            {
                return NotFound();
            }
            List<ReviewOfResApiModel> results = new List<ReviewOfResApiModel>();
            foreach(var item in reviewReses)
            {
                results.Add(new ReviewOfResApiModel { ReviewId = item.ReviewId, RestaurantName = item.Res.Name, Comment = item.Comment, Time = item.Time.Value.ToString(), UserFullName = item.User.Name, Voting = item.Voting});
            }

            return Ok(results);
        }
    }
}
