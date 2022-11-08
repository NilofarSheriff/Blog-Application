using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace DAL_lib
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

        public ICollection<BlogInfo> BlogInfos { get; set; }
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
    public class Model1 : DbContext
    {

        public Model1() : base("Model1")
        {
            Database.SetInitializer(new SeedMethod());
        }
        public virtual DbSet<UserInfo> Users { get; set; }
        public virtual DbSet<AdminInfo> Admins { get; set; }
        public virtual DbSet<BlogInfo> Blogs { get; set; }
    }
    public class SeedMethod : DropCreateDatabaseIfModelChanges<Model1>
    {
        protected override void Seed(Model1 context)
        {
            List<AdminInfo> admin = new List<AdminInfo>();
            admin.Add(new AdminInfo { Email = "nilo@gmail.com", Password = "123" });
            admin.Add(new AdminInfo { Email = "zam@gmail.com", Password = "789" });
            admin.Add(new AdminInfo { Email = "mehar@gmail.com", Password = "456" });
            context.Admins.AddRange(admin);
            List<UserInfo> User = new List<UserInfo>();
            User.Add(new UserInfo
            {
                Name = "Nilofar",
                EmpEmailId = "Nilofar@gmail.com",
                DateOfJoining = new DateTime(2022, 06, 24),
                Passcode = 2529164
            });
            User.Add(new UserInfo
            {
                Name = "Zamruth",
                EmpEmailId = "Zamruth@gmail.com",
                DateOfJoining = new DateTime(2021, 07, 25),
                Passcode = 2429145
            });
            User.Add(new UserInfo
            {
                Name = "Mehar Jabeen",
                EmpEmailId = "Mehar@gmail.com",
                DateOfJoining = new DateTime(2001, 11, 07),
                Passcode = 2025155
            });
            User.Add(new UserInfo
            {
                Name = "Sheriff",
                EmpEmailId = "Sheriff@gmail.com",
                DateOfJoining = new DateTime(1997, 06, 09),
                Passcode = 1945165
            });
            context.Users.AddRange(User);
            List<BlogInfo> BlogList = new List<BlogInfo>();
            BlogList.Add(new BlogInfo
            {
                BlogId = 1,
                DateOfCreation = new DateTime(2019, 03, 13),
                EmpEmailId = "Sheriff@gmail.com",
                Subject = "AI boon or bane ?",
                Title = " AI - Artificial Intelligence",
                BlogUrl = "https://www.geeksforgeeks.org/artificial-intelligence-boon-or-bane/"
            });
            BlogList.Add(new BlogInfo
            {
                BlogId = 2,
                DateOfCreation = new DateTime(2015, 04, 05),
                EmpEmailId = "Mehar@gmail.com",
                Subject = "Mental Health - Harvard Health",
                Title = " Mental Health",
                BlogUrl = "https://www.health.harvard.edu/topics/mental-health"
            });
            BlogList.Add(new BlogInfo
            {
                BlogId = 3,
                DateOfCreation = new DateTime(2020, 10, 13),
                EmpEmailId = "Nilofar@gmail.com",
                Subject = "Women Empowerment - Times of India",
                Title = "Women Empowerment",
                BlogUrl = "https://timesofindia.indiatimes.com/readersblog/joonakkonwar/women-empowerment-3-26133/"
            });
            BlogList.Add(new BlogInfo
            {
                BlogId = 4,
                DateOfCreation = new DateTime(2021, 01, 20),
                EmpEmailId = "Zamruth@gmail.com",
                Subject = "Covid - Hybrid Sector",
                Title = "IT sector after Covid",
                BlogUrl = "https://www.hpe.com/us/en/insights/articles/how-covid-19-accelerated-the-move-to-hybrid-cloud-2005.html"
            });
            BlogList.Add(new BlogInfo
            {
                BlogId = 5,
                DateOfCreation = new DateTime(2022, 05, 09),
                EmpEmailId = "Nilofar@gmail.com",
                Subject = "Trust and Business",
                Title = "Trust affects Business",
                BlogUrl = "https://www.hpe.com/us/en/insights/articles/zero-trust-makes-business-secure-by-default-2010.html"
            });
            context.Blogs.AddRange(BlogList);
            context.SaveChanges();
            base.Seed(context);

        }
    }
}
