using FirstWebCoreApplication2.Models.Abstracts;

namespace FirstWebCoreApplication2.Models
{
    public class Comment:CommonProperty
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        //benim eklediklerim
        public string Content { get; set; }
        public bool IsRead { get; set; } = false;
        public bool IsStatus { get; set; } = false;
        public bool IsDelete { get; set; } = false;
    }
}
