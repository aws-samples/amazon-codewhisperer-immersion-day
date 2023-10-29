using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotionPictures.Models;

namespace MotionPictures.Pages.Movies
{
    public class CreateModel_Solution : PageModel
    {
        private readonly MotionPictures.Data.MovieContext _context;

        public CreateModel_Solution(MotionPictures.Data.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;
        

        // The POST method for the Create page
        // Check the model is valid and not null
        // If the checks pass then add it to the database
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Movie == null || Movie == null)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}