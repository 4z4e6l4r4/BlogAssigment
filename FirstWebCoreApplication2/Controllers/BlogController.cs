using FirstWebCoreApplication2.Models;
using FirstWebCoreApplication2.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebCoreApplication2.Controllers
{
    public class BlogController : Controller
    {
        IBlogService blogService;
        ICategoryService categoryService;
        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            this.blogService = blogService;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var list= await blogService.GetBlogListAsync();
            return View(list);
        }

        public async Task<IActionResult> Add()
        {
            var categoryList=await categoryService.GetAllCategoryAsync();

            return View(categoryList);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Blog blog, int categoryId)
        {
            var result=await blogService.AddBlogAsync(blog, categoryId);
            TempData["Message"] = result ? "Blog Ekleme Başarılı" : "Blog Ekleme Başarısız";

            return RedirectToAction("Add");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await blogService.GetBlogByIdAsync(id);
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Blog blog)
        {
            var result = await blogService.UpdateBlogAsync(blog);
            TempData["Message"] = result ? "Düzenleme Başarılı" : "Düzenleme Başarısız";
            return View(blog);
        }
    }
}
