using FirstWebCoreApplication2.Models;
using FirstWebCoreApplication2.Models.Data;
using FirstWebCoreApplication2.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstWebCoreApplication2.Services
{
    public class CommentService : ICommentService

    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Comment GetCommentById(int id)
        {
            return _context.Comment.Find(id);
        }

        public IEnumerable<Comment> GetCommentsForBlog(int blogId)
        {
            return _context.Comment.Where(c => c.BlogId == blogId && !c.IsDelete).Include(m => m.User).ToList();
        }

        public bool ApproveComment(int id)
        {
            var comment = GetCommentById(id);
            if (comment == null)
            {
                return false;
            }
            comment.IsStatus = true;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteComment(int id)
        {
            var comment = GetCommentById(id);
            if (comment == null)
            {
                return false;
            }
            comment.IsDelete = true;
            _context.SaveChanges();
            return true;
        }

        //public void UpdateComment(Comment comment)
        //{
        //    _context.Comment.Update(comment);
        //    _context.SaveChanges();
        //}


    }
}
