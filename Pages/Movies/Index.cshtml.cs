using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RaviRazorPageMovieApp.Data;
using RaviRazorPageMovieApp.Models;

namespace RaviRazorPageMovieApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RaviRazorPageMovieApp.Data.RaviRazorPageMovieAppContext _context;

        public IndexModel(RaviRazorPageMovieApp.Data.RaviRazorPageMovieAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {

            if (_context.Movies != null)
            {
                Movie = await _context.Movies.Include(m => m.Actors).Include(m => m.Hero).ToListAsync();
            }

            Movie.Count();
        }
    }
}
