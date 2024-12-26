using DevOps_Lab1.Data;
using DevOps_Lab1.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevOps_Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly DataContext _context;

        public CountryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            var countries = await _context.Countries.ToListAsync();

            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country is null)
                return NotFound();

            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult<List<Country>>> AddCountry([FromBody] Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Country>>> UpdateCountry([FromBody] Country updatedCountry)
        {
            var dbCountry = await _context.Countries.FindAsync(updatedCountry.Id);
            if (dbCountry is null)
                return NotFound();

            dbCountry.Name = updatedCountry.Name;
            dbCountry.Continent = updatedCountry.Continent;
            dbCountry.Language = updatedCountry.Language;

            await _context.SaveChangesAsync();

            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Country>>> DeleteCountry(int id)
        {
            var dbCountry = await _context.Countries.FindAsync(id);
            if (dbCountry is null)
                return NotFound();

            _context.Countries.Remove(dbCountry);

            await _context.SaveChangesAsync();

            return Ok(await _context.Countries.ToListAsync());
        }
    }
}
