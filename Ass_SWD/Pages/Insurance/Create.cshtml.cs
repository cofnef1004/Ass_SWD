using Ass_SWD.Model;
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
        public Model.Insurance Insurance { get; set; } = default!;
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
                if (db.Insurances.Any(x => x.PatientId == Insurance.PatientId 
                && x.Number == Insurance.Number && x.Type.Equals(Insurance.Type)))
                {
                    setNotice("Insurance already exist");
                    return Page();
                }
                setNotice("Insurance success");
                db.Insurances.Add(Insurance);
                db.SaveChanges();
                return Page();
            }
        }

        private void setNotice(string notice)
        {
            ViewData["notice"] = notice;
            ViewData["type"] = new SelectList(type);
            Id = Insurance.PatientId;
        }
    }
}
