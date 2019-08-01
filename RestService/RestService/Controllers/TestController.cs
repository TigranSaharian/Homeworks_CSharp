using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestService.Model;

namespace RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public CarContext context;
        public TestController(CarContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Cars> GetInfo()
        {
            return context.cars.ToList();
        }

        [HttpGet("{id}")]
        public Cars GetInfo(string id)
        {
            return context.cars.Where(a=>a.Id==Convert.ToInt32(id)).FirstOrDefault();
        }

        //[Route("/api/Test/Tiko")]
        //[HttpGet]
        ////[HttpGet("/api/Test/Tiko")]
        //public string GetAction()
        //{
        //    return "Fantasy Sport";
        //}
    }
}