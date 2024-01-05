using FirstWebCoreApplication2.Models;
using FirstWebCoreApplication2.Models.Data;
using FirstWebCoreApplication2.Models.Interfaces;
using FirstWebCoreApplication2.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FirstWebCoreApplication2.Services
{
    public class BlogService : IBlogService
    {
        ApplicationDbContext db;
        public BlogService(ApplicationDbContext db)
        { 
            this.db = db;
        }
        public Task<bool> AddBlogAsync(Blog blog, int categoryId)
        {
            var result = false;
            if (!String.IsNullOrEmpty(blog.Name))
            {
                blog.CreateDate = DateTime.Now;
                blog.UserId = 1;
                db.Blog.AddAsync(blog);
                db.SaveChanges();

                var blogCategory=new BlogCategory()
                {
                    BlogId= blog.Id,
                    CategoryId= categoryId
                };
                db.BlogCategory.AddAsync(blogCategory);
                db.SaveChanges();
                result = true;
            }
            return Task.FromResult(result);
        }

        public Task<bool> DeleteBlogAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Blog> GetBlogByIdAsync(int id)
        {
            var blog=db.Blog.Find(id);
            return Task.FromResult(blog);
        }

        public Task<List<BlogViewModel>> GetBlogListAsync()
        {
            var blogInformation = from blog in db.Blog.ToList()
                                  join blogCategory in db.BlogCategory.ToList()
                                  on blog.Id equals blogCategory.BlogId
                                  join user in db.User
                                  on blog.UserId equals user.Id
                                  where blog.IsDelete == false
                                  
                                  group new { Blog = blog, User = user } by blog.Id into groupedCategories

                                  select new BlogViewModel
                                  {
                                      Id = groupedCategories.Key,
                                      Name = groupedCategories.First().Blog.Name,
                                      ShortDescription = groupedCategories.First().Blog.ShortDescription,
                                      CreateDate = groupedCategories.First().Blog.CreateDate,
                                      IsStatus = groupedCategories.First().Blog.IsStatus,
                                      UserId = groupedCategories.First().User.Id,
                                      Username = groupedCategories.First().User.Username,
                                      CommentCount = db.Comment.Where(x => x.BlogId == groupedCategories.Key).Count(),
                                      LikeCount = db.BlogLike.Where(x => x.BlogId == groupedCategories.Key).Count(),

                                      Categories = (from category in db.Category 
                                                    join gc in db.BlogCategory 
                                                    on category.Id equals gc.CategoryId 
                                                    where groupedCategories.Key==gc.BlogId
                                                    select category).ToList(),

                                      Comments = db.Comment.Where(x => x.BlogId == groupedCategories.Key).ToList(),
                                  };

            return Task.FromResult(blogInformation.ToList());
        }

        public Task<List<Blog>> GetBlogListByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBlogAsync(Blog blog)
        {
            var blogInformation = db.Blog.Find(blog.Id);
            var result = false;
            if (blogInformation!= null)
            {
                blogInformation.Description = blog.Description;
                db.SaveChanges();
                result= true;
            }
            return Task.FromResult(result);
        }
    }
}
