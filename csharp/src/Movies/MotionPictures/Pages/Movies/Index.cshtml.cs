using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotionPictures.Data;
using MotionPictures.Models;

namespace MotionPictures.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MotionPictures.Data.MovieContext _context;

        public IndexModel(MotionPictures.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
