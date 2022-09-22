using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Img { get; set; }

        [ForeignKey("user")]
        public int? UserID { get; set; }

        [ForeignKey("hashtag")]
        public int HashId { get; set; }

        // Navigation Property
        public User user { get; set; }
        public Hashtag hashtag { get; set; }
        public List<Comment> comments { get; set; }
    }
}
