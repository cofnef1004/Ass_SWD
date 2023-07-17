using Ass_SWD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ass_SWD.Pages.Category
{
    public class UpdateModel : PageModel
    {
        public ICategoryService _categoryService;
        public Models.Category _category { get; set; } = default!;

        public UpdateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public void OnGet(int CategoryId)
        {
            _category =  _categoryService.GetCategoryById(CategoryId);
        }
        public IActionResult OnPost(int CategoryId)
        {
            _category = _categoryService.GetCategoryById(CategoryId);
            string name = Request.Form["name"];
            string des = Request.Form["description"];
            try
            {
                _category.CategoryName = name;
                _category.Description = des;
                _categoryService.UpdateCategory(_category);
                TempData["Message"] = "Update Success";
                return Redirect("/Category/ViewDetail/" + CategoryId);
            }
            catch (Exception)
            {
                TempData["Message"] = "Update Fail";
                return Page();
            }
        }
    }
}
