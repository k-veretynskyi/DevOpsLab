using DevOps_Lab1.Data;
using DevOps_Lab1.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevOps_Lab1.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CityController : ControllerBase
        {
            private readonly DataContext _context;

            public CityController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<List<City>>> GetAllCities()
            {
                var cities = await _context.Cities.ToListAsync();

                return Ok(cities);
            }
            [HttpGet("{id}")]
            public async Task<ActionResult<City>> GetCity(int id)
            {
                var city = await _context.Cities.FindAsync(id);
                if (city is null)
                    return NotFound();

                return Ok(city);
            }
            [HttpPost]
            public async Task<ActionResult<List<City>>> AddCity([FromBody] City city)
            {
                _context.Cities.Add(city);
                await _context.SaveChangesAsync();

                return Ok(await _context.Cities.ToListAsync());
            }
            [HttpPut]
            public async Task<ActionResult<List<City>>> UpdateCity([FromBody] City updatedCity)
            {
                var dbCity = await _context.Cities.FindAsync(updatedCity.Id);
                if (dbCity is null)
                    return NotFound();

                dbCity.Name = updatedCity.Name;
                dbCity.FoundationYear = updatedCity.FoundationYear;
                dbCity.PostCode = updatedCity.PostCode;

                await _context.SaveChangesAsync();

                return Ok(await _context.Cities.ToListAsync());
            }

            [HttpDelete]
            public async Task<ActionResult<List<City>>> DeleteCity(int id)
            {
                var dbCity = await _context.Cities.FindAsync(id);
                if (dbCity is null)
                    return NotFound();

                _context.Cities.Remove(dbCity);

                await _context.SaveChangesAsync();

                return Ok(await _context.Cities.ToListAsync());
            }
        }
    }
