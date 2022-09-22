using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(20,ErrorMessage ="max length is 20 char")]
        public string fname { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(20, ErrorMessage = "max length is 20 char")]
        public string lname { get; set; }

        public string Gender { get; set; }
        [Required(ErrorMessage ="*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        [RegularExpression("^01[0125][0-9]{8}")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="*")]
        //[RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$",
        //    ErrorMessage = "password must be Minimum eight characters, at least one letter and one number")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password",ErrorMessage ="password does not match")]
        public string ConfirmPassword { get; set; }

        public bool? MaritaleState { get; set; } 

        public string? School { get; set; }

        public string? work { get; set; }
        public string? Address { get; set; }

        // Navigation Property
        public List<Post> posts { get; set; }
        public List<Comment> comments { get; set; }
    }
}
