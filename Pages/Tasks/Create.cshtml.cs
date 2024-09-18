using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using System.Threading.Tasks;

namespace TaskManagementSystem.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly TaskDbContext _context;

        public CreateModel(TaskDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskItem TaskItem { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TaskItems.Add(TaskItem);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
