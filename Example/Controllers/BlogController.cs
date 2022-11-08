using Example.Data;
using Example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Example.Controllers
{
    [ApiController]
    [Route("api/Blog")]
    public class BlogController : Controller
    {
        private readonly BlogDB dbcontext;

        public BlogController(BlogDB dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await dbcontext.Blogs.ToListAsync());

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var User = await dbcontext.Blogs.FindAsync(id);
            if (User != null)
            {
                return Ok(User);
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddBlogRequest addUserRequest)
        {
            var UserInfo = new BlogInfo()
            {
                EmpEmailId = addUserRequest.EmpEmailId,
                BlogId = addUserRequest.BlogId,
                BlogUrl = addUserRequest.BlogUrl,
                DateOfCreation = addUserRequest.DateOfCreation,
                Subject = addUserRequest.Subject,
                Title = addUserRequest.Title,
                UserInfo = addUserRequest.UserInfo,
                

            };
            await dbcontext.Blogs.AddAsync(UserInfo);
            await dbcontext.SaveChangesAsync();

            return Ok(UserInfo);

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, UpdateBlogRequest updateUserRequest)
        {
            var User = await dbcontext.Blogs.FindAsync(id);
            if (User != null)
            {
                var UserInfo = new BlogInfo()
                {
                    EmpEmailId = updateUserRequest.EmpEmailId,
                   
                    BlogUrl = updateUserRequest.BlogUrl,
                    DateOfCreation = updateUserRequest.DateOfCreation,
                    Subject = updateUserRequest.Subject,
                    Title = updateUserRequest.Title
                    


                };

                await dbcontext.SaveChangesAsync();
                return Ok(User);

            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var User = await dbcontext.Blogs.FindAsync(id);
            if (User != null)
            {
                dbcontext.Blogs.Remove(User);
                await dbcontext.SaveChangesAsync();
                return Ok("User Deleted");

            }
            return NotFound();
        }
    }
}
