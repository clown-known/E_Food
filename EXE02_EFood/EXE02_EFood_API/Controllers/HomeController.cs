using AutoMapper;
using EXE02_EFood_API.ApiModels;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IDishRepository dishRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IDishCategoryRepository dishCategoryRepository;


        public HomeController(IDishRepository dishRepository, ICategoryRepository categoryRepository, IDishCategoryRepository dishCategoryRepository)
        {
            this.dishRepository = dishRepository;
            this.categoryRepository = categoryRepository;
            this.dishCategoryRepository = dishCategoryRepository;
        }
        [HttpGet]
        public IActionResult Home()
        {
            HomeApiModel result = new HomeApiModel();
            result.dish = dishRepository.GetAll();
            foreach (Category cate in categoryRepository.GetAll()) {
                result.cate.Add(new CateHome { id = cate.CategoryId,name = cate.CategoryName});
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("cate")]
        public IActionResult Filter(string dishid)
        {
            HomeApiModel result = new HomeApiModel();
            if (dishid == null)
                result.dish = dishRepository.GetAll();
            else
            {
                int idd = Int32.Parse(dishid);
                foreach(int d in dishCategoryRepository.GetDishCategories(idd))
                {
                    result.dish.Add(dishRepository.Get(d));
                }
            }
            foreach (Category cate in categoryRepository.GetAll()) {
                result.cate.Add(new CateHome { id = cate.CategoryId, name = cate.CategoryName });
            }
            return Ok(result);
        }
    }
}
