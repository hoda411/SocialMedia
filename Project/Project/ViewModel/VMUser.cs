using System.ComponentModel.DataAnnotations;

namespace Project.ViewModel
{
    public class VMUser
    {

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "*")]
        public string pass { get; set; }

        public string errormessage { get; set; } = "";
    }
}
