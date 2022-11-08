using Microsoft.EntityFrameworkCore;
using Example.Models;

namespace Example.Data
{
    public class BlogDB : DbContext
    {
        public BlogDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<AdminInfo> Admins { get; set; }
        public DbSet<BlogInfo> Blogs { get; set; }
    }
}
