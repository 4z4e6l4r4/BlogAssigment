using FirstWebCoreApplication2.Models.Data;
using FirstWebCoreApplication2.Models.Interfaces;
using FirstWebCoreApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebCoreApplication2.Services
{
    public class LikeService : ILikeService
    {
        private readonly ApplicationDbContext _context;

        public LikeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogLike> GetLikesForBlog(int blogId)
        {
            return _context.BlogLike.Where(bl => bl.BlogId == blogId).Include(m => m.User).ToList();
        }
    }

}
