namespace FirstWebCoreApplication2.Models.Interfaces
{
    public interface ICommentService
    {
        Comment GetCommentById(int id);
        IEnumerable<Comment> GetCommentsForBlog(int blogId);
        bool ApproveComment(int id);
        bool DeleteComment(int id);
        //void UpdateComment(Comment comment);
    }

}
