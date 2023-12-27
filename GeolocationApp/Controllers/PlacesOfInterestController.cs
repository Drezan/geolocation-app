using GeolocationApp.Data;
using GeolocationApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace GeolocationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesOfInterestController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PlacesOfInterestController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllPOI()
        {
            try
            {
                List<PlaceOfInterest> listPOI = await _context.Places.ToListAsync();

                return Ok(listPOI);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePOI(PlaceOfInterest place)
        {
            try
            {
                _context.Places.Add(place);
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
        public async Task<IActionResult> UpdatePOI(PlaceOfInterest place)
        {
            try
            {
                _context.Places.Update(place);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeletePOI(int placeId)
        {
            try
            {
                PlaceOfInterest? place = _context.Places.FirstOrDefault(c => c.Id == placeId);

                if (place is null)
                    throw new Exception("The place do not exists.");

                _context.Places.Remove(place);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [Authorize]
        [HttpGet("PoiByUser")]
        public async Task<IActionResult> SearchPlaceOfInterest(int userId, double radiusInMeters, string serviceType)
        {
            List<PlaceOfInterest> places = new List<PlaceOfInterest>();

            //Find the current User Location
            Location? userLocation = await _context.Locations.Where(u => u.UserId == userId).OrderByDescending(o => o.TimeStamp).FirstOrDefaultAsync();
            
            if (userLocation != null)
            {
                places = await _context.Places.Where(l => Math.Pow(userLocation.Latitude - l.Latitude, 2) +
                                                          Math.Pow(userLocation.Longitude - l.Longitude, 2)
                                                          <= Math.Pow(radiusInMeters / 111300, 2) //Convert Radius Meters to Grades
                                                          && l.BusinessType.Contains(serviceType.ToLower())).ToListAsync();
            }

            return Ok(places);
        }
    }
}
