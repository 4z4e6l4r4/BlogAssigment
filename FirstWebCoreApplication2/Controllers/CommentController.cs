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

        public IActionResult Accept(int id, int blogid) 
        { 

            commentService.ApproveComment(id);
            return RedirectToAction("Index", new { id = blogid });
        }

        public IActionResult Delete(int id, int blogid)
        {
            commentService.DeleteComment(id);
            return RedirectToAction("Index", new { id = blogid });
        }



    }
}
