using Example.Data;
using Example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Example.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserInfoController : Controller
    {
        private readonly BlogDB dbcontext;

        public UserInfoController(BlogDB dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await dbcontext.Users.ToListAsync());

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            var User = await dbcontext.Users.FindAsync(id);
            if(User != null) { 
            return Ok(User);    
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var UserInfo = new UserInfo()
            {
                EmpEmailId = addUserRequest.EmpEmailId,
                Name = addUserRequest.Name,
                DateOfJoining = addUserRequest.DateOfJoining,
                Passcode = addUserRequest.Passcode,

            };
             await dbcontext.Users.AddAsync(UserInfo);
            await dbcontext.SaveChangesAsync();

            return Ok(UserInfo);

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute]string id,UpdateUserRequest updateUserRequest)
        {
           var User = await dbcontext.Users.FindAsync(id);
            if (User != null)
            {
                User.Name = updateUserRequest.Name;
                User.DateOfJoining=updateUserRequest.DateOfJoining;
                User.Passcode = updateUserRequest.Passcode;
                await dbcontext.SaveChangesAsync();
                return Ok(User);

            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var User = await dbcontext.Users.FindAsync(id);
            if(User != null)
            {
                dbcontext.Users.Remove(User);
                await dbcontext.SaveChangesAsync();
                return Ok("User Deleted");
                
            }
            return NotFound();
        }

    }
}
