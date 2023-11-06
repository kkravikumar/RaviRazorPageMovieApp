using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RaviRazorPageMovieApp.Data;
using RaviRazorPageMovieApp.Models;

namespace RaviRazorPageMovieApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RaviRazorPageMovieApp.Data.RaviRazorPageMovieAppContext _context;

        public CreateModel(RaviRazorPageMovieApp.Data.RaviRazorPageMovieAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;
        
        public List<SelectListItem> Hero { get; set; }



        public IActionResult OnGet()
        {
            Hero = _context.Actors.Select(a =>
                        new SelectListItem() {
                            Value = a.Id.ToString(),
                            Text = a.Name
                        }
                        ).ToList();

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Movies == null || Movie == null)
            {
                return Page();
            }
            
            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
