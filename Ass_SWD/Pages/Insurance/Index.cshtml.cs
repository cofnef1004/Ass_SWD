using Ass_SWD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace Ass_SWD.Pages.Insurance
{
    public class IndexModel : PageModel
    {
        public IList<Models.Insurance> Insurances { get; set; } = default!;
        public int Id = default!;
        public void OnGet(int id)
        {
            using (var db = new MyStoreContext())
            {
                Id = id;
                Insurances = db.Insurances.Where(i => i.PatientId == id).ToList();
            }
        }
    }
}
