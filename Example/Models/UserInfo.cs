using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Example.Models
{
    public class AdminInfo
    {
        [Key, Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
    
    public class UserInfo
    {
        [Key, Required]
        [DataType(DataType.EmailAddress)]
        public string EmpEmailId { get; set; }
        [MinLength(3, ErrorMessage = "Name should have more than three character")]
        [MaxLength(30, ErrorMessage = "Maximum length of Name is 30 characters")]
        public string Name { get; set; }

        public DateTime DateOfJoining { get; set; }
        public int Passcode { get; set; }

        
    }
    public class BlogInfo
    {
        [Key, Required]
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime DateOfCreation { get; set; }

        [DataType(DataType.Url)]
        public string BlogUrl { get; set; }

        public string EmpEmailId { get; set; }
        [ForeignKey("EmpEmailId")]
        public virtual UserInfo UserInfo { get; set; }

    }
    



}
