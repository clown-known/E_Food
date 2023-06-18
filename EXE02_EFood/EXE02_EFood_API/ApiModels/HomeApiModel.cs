using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.ApiModels
{
    public class HomeApiModel
    {
        public List<CateHome> cate { get; set; }
        public List<Dish> dish { get; set; }
        public HomeApiModel()
        {
            cate = new List<CateHome>();
            dish = new List<Dish>();
        }
        
    }
    public class CateHome
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
