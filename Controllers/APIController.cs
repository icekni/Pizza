using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoPizza.Data;
using RestoPizza.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestoPizza.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class APIController : Controller
    {
        private readonly DataContext _context;
        public IList<Pizza> Pizzas { get; set; }

        public APIController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GetPizzas")]
        public IActionResult GetPizza()
        {
            return Json(_context.Pizzas.ToList());
        }

        [HttpGet]
        [Route("GetPizza/{pizzaId}")]
        public IActionResult GetPizzaByID(int pizzaId)
        {
            return Json(_context.Pizzas.Single(pizza => pizza.Id == pizzaId));
        }
    }
}
