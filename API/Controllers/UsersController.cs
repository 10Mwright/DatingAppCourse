using System;
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
    [Route("api/[controller]")] //i.e. in this case api/UsersController
    public class UsersController : ControllerBase
    {
        private DataContext _context { get; }
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() { //API Endpoint
            return await _context.Users.ToListAsync(); //Get list of users in DB
        }

        //api/users/3 -> user id of 3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) { //API Endpoint
            return await _context.Users.FindAsync(id); //Get user by their id
        }
    }
}