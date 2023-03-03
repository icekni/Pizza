using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoPizza.Data;
using RestoPizza.Models;

namespace RestoPizza.Pages.Admin.Pizzas
{
    public class IndexModel : PageModel
    {
        private readonly RestoPizza.Data.DataContext _context;

        public IndexModel(RestoPizza.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizza { get;set; }

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizzas.ToListAsync();
        }
    }
}
