using FirstWebCoreApplication2.Models.Abstracts;

namespace FirstWebCoreApplication2.Models
{
    public class Comment:CommonProperty
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
