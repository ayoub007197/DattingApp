using DattingApp.Data;
using DattingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DattingApp.Controllers
{
    [ApiController]
    [Route("{api/controller}")] // api/Users
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
            
        }
        [HttpGet]

        public async  Task<ActionResult <IEnumerable<AppUser>>> GetUsers() {
        
            // we use actionResult as a return type so we can get the status of our Http request exple : 200 OK
            var users= await _context.Users.ToListAsync();
            return users;
        
        }

        [HttpGet("{id}")]

        public async Task< ActionResult<AppUser>> GetUser(int id)
        {
            
            // we use actionResult as a return type so we can get the status of our Http request exple : 200 OK
            
            return await _context.Users.FindAsync(id);
        }


    }
}
