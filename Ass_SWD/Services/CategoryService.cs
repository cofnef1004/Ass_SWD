using Ass_SWD.Models;

namespace Ass_SWD.Services
{
    public class CategoryService : ICategoryService
    {
        MyStoreContext _context;

        public CategoryService(MyStoreContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public List<Category> GetAllCategory()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            _context.Update(category);
            _context.SaveChanges();
        }
    }
}
