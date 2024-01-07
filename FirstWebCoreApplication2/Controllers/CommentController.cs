using FirstWebCoreApplication2.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebCoreApplication2.Controllers
{
    public class CommentController : Controller
    {
        ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IActionResult Index(int id)
        {
            var AllComments = commentService.GetCommentsForBlog(id);
            return View(AllComments);
        }

        public IActionResult Accept(int id) 
        { 
            commentService.ApproveComment(id);
            return RedirectToAction("Index", new { id = id });
        }

        public IActionResult Delete(int id)
        {
            commentService.DeleteComment(id);
            return RedirectToAction("Index", new { id = id });
        }



    }
}
