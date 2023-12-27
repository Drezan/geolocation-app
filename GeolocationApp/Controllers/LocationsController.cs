using GeolocationApp.Data;
using GeolocationApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeolocationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LocationsController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RegisterLocation(Location location)
        {
            try
            {
                _context.Locations.Add(location);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(Location location)
        {
            try
            {
                Location locationUpdated = new Location()
                {
                    UserId = location.UserId,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    TimeStamp = DateTime.UtcNow
                };

                _context.Locations.Update(locationUpdated);
                await _context.SaveChangesAsync();

                return Ok(locationUpdated);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            try
            {
                Location? user = await _context.Locations.FirstOrDefaultAsync(c => c.LocationId == locationId);

                if (user is null)
                    throw new Exception("The user do not exists.");

                _context.Locations.Remove(user);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                List<Location> listLocations = await _context.Locations.ToListAsync();

                return Ok(listLocations);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
