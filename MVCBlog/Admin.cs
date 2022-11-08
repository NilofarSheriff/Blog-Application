namespace MVCBlog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        [Key]
        [StringLength(450)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
