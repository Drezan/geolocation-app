using GeolocationApp.Data;
using GeolocationApp.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeolocationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<User> listUsers = _context.Users.ToList();

                return Ok(listUsers);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                User? user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();

                if (user is null)
                    return Ok("The user you are querying does not exist.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try 
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: "+ ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int userId)
        {
            try
            {
                User? user = _context.Users.FirstOrDefault(c => c.UserId == userId);

                if (user is null)
                    throw new Exception("The user do not exists.");

                _context.Users.Remove(user);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
