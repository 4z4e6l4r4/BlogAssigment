using FirstWebCoreApplication2.Models.Abstracts;

namespace FirstWebCoreApplication2.Models
{
    public class Blog:CommonProperty
    {
        public DateTime CreateDate { get; set; }
        public string? Image { get; set; }
        public string? ShortDescription { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<BlogLike> BlogLikes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
