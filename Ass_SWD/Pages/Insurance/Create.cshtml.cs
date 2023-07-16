using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ass_SWD.Pages.Insurance
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Models.Insurance Insurance { get; set; } = default!;
        private List<String> type = new List<String> { "Health", "Treatment", "Medical" };

        public int Id;
        public IActionResult OnGet(int id)
        {
            Id = id;
            ViewData["notice"] = "";
            ViewData["type"] = new SelectList(type);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {


            using (var db = new MyStoreContext())
            {
                if (db.Insurances.Any(x => x.PatientId == Insurance.PatientId && x.Number == Insurance.Number))
                {
                    ViewData["notice"] = "Insurance already exist";
                    ViewData["type"] = new SelectList(type);
                    return Page();
                }
                ViewData["notice"] = "Insurance success";
                ViewData["type"] = new SelectList(type);
                db.Insurances.Add(Insurance);
                db.SaveChanges();
                Id = Insurance.PatientId;
                return Page();
            }
        }
    }
}
