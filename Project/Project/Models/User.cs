using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class User
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(20,ErrorMessage ="Max length is 20 character")]
        public string FName { get; set; }
       
        
        [Required(ErrorMessage = "*")]
        [StringLength(20, ErrorMessage = "Max length is 20 character")]
        public string LName { get; set; }
      
        
        [Required(ErrorMessage = "*")]
        public string gender { get; set; }
        
        
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
       
        
        [Required(ErrorMessage = "*")]
        [RegularExpression("^01[0125][0-9]{8}")]
        public string phone { get; set; }
       
        
        [Required(ErrorMessage = "*")]
        public string pass { get; set; }
        
        
        [Required(ErrorMessage = "*")]
        [Compare("pass", ErrorMessage = "Tow passwords does not math")]
        [NotMapped]
        public string confirmpass { get; set; }
        public bool? maritalestate { get; set; }
        public string? school { get; set; }
        public string? address { get; set; }



    }
}
