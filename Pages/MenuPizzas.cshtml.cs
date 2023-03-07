using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoPizza.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoPizza.Pages
{
    public class MenuPizzasModel : PageModel
    {
        private readonly Data.DataContext _context;
        public IList<Pizza> Pizzas { get; set; }

        public MenuPizzasModel(Data.DataContext context)
        {
            this._context = context;
        }

        public async Task OnGetAsync()
        {
            Pizzas = await _context.Pizzas.OrderBy(pizza => pizza.prix).ToListAsync();
        }
    }
}
