using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    public class UpdateBlogRequest
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
