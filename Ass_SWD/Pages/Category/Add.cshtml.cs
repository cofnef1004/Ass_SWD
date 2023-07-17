using Ass_SWD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ass_SWD.Pages.Category
{
    public class AddModel : PageModel
    {
        public ICategoryService _categoryService;
        public Models.Category _category { get; set; } = default!;

        public AddModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            string name = Request.Form["name"];
            string des = Request.Form["description"];
            _category = new Models.Category();
            try
            {
                _category.CategoryName = name;
                _category.Description = des;
                _categoryService.AddCategory(_category);
                TempData["Message"] = "Add Success";
                return Redirect("/Category/View");
            }
            catch (Exception)
            {
                TempData["Message"] = "Add Fail";
                return Page();
            }
        }


    }
}
