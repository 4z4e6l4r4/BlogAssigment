namespace FirstWebCoreApplication2.Models.Interfaces
{
    public interface ILikeService
    {
        IEnumerable<BlogLike> GetLikesForBlog(int blogId);
    }

}
