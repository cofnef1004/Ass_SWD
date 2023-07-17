using Ass_SWD.Models;

namespace Ass_SWD.Services
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategory();
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public Category GetCategoryById(int categoryId);
    }
}
