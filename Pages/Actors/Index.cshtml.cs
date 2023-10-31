using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RaviRazorPageMovieApp.Data;
using RaviRazorPageMovieApp.Models;

namespace RaviRazorPageMovieApp.Pages.Actors
{
    public class IndexModel : PageModel
    {
        private readonly RaviRazorPageMovieApp.Data.RaviRazorPageMovieAppContext _context;

        public IndexModel(RaviRazorPageMovieApp.Data.RaviRazorPageMovieAppContext context)
        {
            _context = context;
        }

        public IList<Actor> Actor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Actors != null)
            {
                Actor = await _context.Actors.ToListAsync();
            }
        }
    }
}
