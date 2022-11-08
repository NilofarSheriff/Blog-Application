namespace MVCBlog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Blog
    {
        public int BlogId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Subject { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfCreation { get; set; }

        [Required]
        public string BlogUrl { get; set; }

        [Required]
        [StringLength(450)]
        public string EmpEmailId { get; set; }

        public virtual User User { get; set; }
    }
}
