using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]

        public string Body { get; set; }

        public string Sticker { get; set; }
        [ForeignKey("post")]
        public int PostID { get; set; }

        [ForeignKey("user")]
        public int UserId { get; set; }

        // Navigation Property
        public Post post { get; set; }
        public User user { get; set; }
    }
}
