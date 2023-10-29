using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotionPictures.Data;
using MotionPictures.Models;

namespace MotionPictures.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MovieContext _context;

        public CreateModel(MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;
        
        public IActionResult OnGet()
        {
            return Page();
        } 

        // Stubbed implementation of POST method 
        // Delete the entire method before asking CodeWhisperer for inferences
        public async Task<IActionResult> OnPostAsync()
        {
          return null;
        }
    }
}
