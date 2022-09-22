using System.ComponentModel.DataAnnotations;

namespace SocialMedia.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        //[RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$",
        //    ErrorMessage = "password must be Minimum eight characters, at least one letter and one number")]
        public string Password { get; set; }

        public string Message { get; set; } = "";
    }
}
