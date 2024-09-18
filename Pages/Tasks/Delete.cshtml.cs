using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using System.Threading.Tasks;

namespace TaskManagementSystem.Pages.Tasks
{
    public class DeleteModel : PageModel
    {
        private readonly TaskDbContext _context;

        public DeleteModel(TaskDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskItem TaskItem { get; set; }

        // Handles the GET request to load the task details for confirmation
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskItem = await _context.TaskItems.FindAsync(id);

            if (TaskItem == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Handles the POST request to actually delete the task
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskItem = await _context.TaskItems.FindAsync(id);

            if (TaskItem != null)
            {
                _context.TaskItems.Remove(TaskItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
