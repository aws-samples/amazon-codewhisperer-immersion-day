using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotionPictures.Data;
using MotionPictures.Models;

namespace MotionPictures.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly MovieContext _context;

        public DeleteModel(MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.ID == id);

            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Movie = movie;
            }
            return Page();
        }

        // Stubbed implementation of POST method 
        // Delete the entire method before asking CodeWhisperer for inferences
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            return null;
        }
    }
}
