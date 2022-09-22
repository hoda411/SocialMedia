using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class Hashtag
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        
        public string Title { get; set; }
        [Required(ErrorMessage = "*")]

        public string Description { get; set; }

        // Navigation Property
        public List<Post> posts { get; set; }
    }
}
