using FormulaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FormulaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private static List<Driver> _drivers = new List<Driver>()
        {
            new Driver()
            {
                Id = 1,
                Name = "Test1",
                DeriverNumber = "TestNum1",
                Team = "TestTeam1"
            },
            new Driver()
            {
                Id = 2,
                Name = "Test2",
                DeriverNumber = "TestNum2",
                Team = "TestTeam2"
            },
            new Driver()
            {
                Id = 3,
                Name = "Test3",
                DeriverNumber = "TestNum3",
                Team = "TestTeam3"
            }
        };

        [ProducesResponseType(200)]
        [HttpGet]
        public IActionResult GetDriversAll()
        {
            var drivers = _drivers.ToList();
            return Ok(drivers);
        }
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public IActionResult GetDriverById(int id)
        {
            var driver = _drivers.FirstOrDefault(x => x.Id == id);
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }
        [ProducesResponseType(201)]
        [HttpPost]
        public IActionResult PostDriver(Driver driver) {
            var newDriver = new Driver
            {
                Id = _drivers.ToList().Last().Id + 1,
                Name = driver.Name,
                DeriverNumber = driver.DeriverNumber,
                Team = driver.Team

            };
            _drivers.Add(newDriver);
            return Ok(newDriver);
        }
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(int id)
        {
            var driver = _drivers.FirstOrDefault(x => x.Id == id);
            if (driver is null)
            {
                return BadRequest();
            }
            _drivers.Remove(driver);
            return Ok("Driver was deleted succesfully");

        }
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut]
        public IActionResult UpdateDriver(int id, Driver request)
        {
            var driver = _drivers.FirstOrDefault(x => x.Id == id);

            if (driver is null) return NotFound();

            driver.Name = request.Name;
            driver.DeriverNumber = request.DeriverNumber;
            driver.Team = request.Team;

            return Ok(driver);


        }

    } 

}

