using FirstWebCoreApplication2.ViewModels;

namespace FirstWebCoreApplication2.Models.Interfaces
{
    public interface IBlogService
    {
        public Task<List<BlogViewModel>> GetBlogListAsync();
        public Task<Blog> GetBlogByIdAsync(int id);
        public Task<bool> DeleteBlogAsync(int id);
        public Task<bool> AddBlogAsync(Blog blog,int categoryId);
        public Task<bool> UpdateBlogAsync(Blog blog);
        public Task<List<Blog>> GetBlogListByCategoryAsync(int categoryId);
    }
}
