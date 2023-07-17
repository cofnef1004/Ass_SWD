using Ass_SWD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ass_SWD.Pages.Category
{
    public class ViewDetailModel : PageModel
    {
        public ICategoryService _categoryService { get; set; }
        public Models.Category _category { get; set; }

        public ViewDetailModel (ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void OnGet(int CategoryId)
        {
            _category = _categoryService.GetCategoryById(CategoryId);
        }
    }
}
