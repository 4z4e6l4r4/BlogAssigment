using FirstWebCoreApplication2.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebCoreApplication2.Controllers
{
    public class LikeController : Controller
    {
        ILikeService likeService;

        public LikeController (ILikeService likeService)
        {
            this.likeService=likeService;
        }

        public IActionResult Index(int BlogId)
        {
            var likeCount = likeService.GetLikesForBlog(BlogId);

            return View(likeCount);

        }
    }
}
