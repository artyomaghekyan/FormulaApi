using FormulaApi.Data;
using FormulaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FormulaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly DriverDbContext _context;
        public DriverController(DriverDbContext context)
        {
            _context = context;
        }

        [ProducesResponseType(200)]
        [HttpGet]
        public IActionResult GetDriversAll()
        {
            var drivers = _context.Drivers.ToList();
            return Ok(drivers);
        }
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverById(int id)
        {
            try
            {
                var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
                if (driver == null)
                {
                    return NotFound();
                }
                return Ok(driver);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<IActionResult> PostDriver(Driver driver)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var newDriver = new Driver
                    {
                        Name = driver.Name,
                        DriverNumber = driver.DriverNumber,
                        Team = driver.Team

                    };
                    await _context.Drivers.AddAsync(newDriver);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return Ok(newDriver);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex.Message);
                }
            }

        }
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
                    if (driver is null)
                    {
                        return BadRequest();
                    }
                    _context.Drivers.Remove(driver);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return Ok("Driver was deleted succesfully");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex.Message);
                }
            }


        }
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, Driver request)
        {
            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            driver.Name = request.Name;
            driver.DriverNumber = request.DriverNumber;
            driver.Team = request.Team;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while updating the driver: {ex.Message}");
            }

            return Ok(driver);
        }


    }
}

