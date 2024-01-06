using FirstWebCoreApplication2.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebCoreApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        // Yorum servisi enjekte edilir
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // Yorumları listeleme, okundu olarak işaretleme, onaylama ve silme gibi metodlar eklenecek
    }

}
