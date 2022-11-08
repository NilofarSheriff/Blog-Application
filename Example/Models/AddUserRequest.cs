using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    public class AddUserRequest
    {
        
        [DataType(DataType.EmailAddress)]
        public string EmpEmailId { get; set; }
        [MinLength(3, ErrorMessage = "Name should have more than three character")]
        [MaxLength(30, ErrorMessage = "Maximum length of Name is 30 characters")]
        public string Name { get; set; }

        public DateTime DateOfJoining { get; set; }
        public int Passcode { get; set; }
    }
}
