using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    //Inorder to get to this controller, the clients need to specify 'api/' in their url
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        //to get the data into the database, we are gonna use dependency injection
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        //Added two end points -> one to get all the users from our database ->another to get the specific user

        // api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //creating a variable to store the users 
            return await _context.Users.ToListAsync();
        }

        //api/users/1 => id 
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}