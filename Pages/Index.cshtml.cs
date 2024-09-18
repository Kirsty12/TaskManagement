using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;
using TaskManagementSystem.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace TaskManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TaskDbContext _context;

        public IndexModel(TaskDbContext context)
        {
            _context = context;
        }

        public IList<TaskItem> TaskItems { get; set; }

        //Element to allow search functionality
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set;}

        //Element to all filtering
        [BindProperty(SupportsGet = true)]
        public string CompletionStatus { get; set; } = "all";       

        //OnGet function to pull all task items from db and display on index page
        public async Task OnGetAsync(string searchString, string completionStatus)
        {
            SearchString = searchString;
            CompletionStatus = completionStatus; 

            var query = _context.TaskItems.AsQueryable(); //Select all tasks 

            if(!string.IsNullOrEmpty(SearchString))
            {
                query = query.Where(t => t.Title.ToLower().Contains(SearchString.ToLower())); //Apply search on Title column - case sensitive search 
            }

            // Apply completion status filter
            if (CompletionStatus == "completed")
            {
                query = query.Where(t => t.IsComplete == true);
            }
            else if (CompletionStatus == "incomplete")
            {
                query = query.Where(t => t.IsComplete == false);
            }

            //Display all tasks
            TaskItems = await query.ToListAsync(); //Display all tasks 
        }

        //API for Calendar View - Get Tasks for Calendar
        public async Task<IActionResult> OnGetGetTasksForCalendarAsync()
        {
             var tasks = await _context.TaskItems
                              .Select(t => new
                              {
                                  id = t.Id,
                                  title = t.Title,
                                  start = t.DueDate.ToString("yyyy-MM-dd"), 
                                  color = t.IsComplete ? "#28a745" : "#dc3545", // Green for complete, Red for incomplete  
                                  completed = t.IsComplete
                              })
                              .ToListAsync();

        return new JsonResult(tasks);
        }

    }

}
