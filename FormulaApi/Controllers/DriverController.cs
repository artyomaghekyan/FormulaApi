using FormulaApi.Core;
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
        private readonly IUnitOfWork _unitOfWork;
        public DriverController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<IActionResult> GetDriversAll()
        {

            return Ok(await _unitOfWork.Drivers.All());
        }
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverById(int id)
        {
            try
            {
                var driver = _unitOfWork.Drivers.GetById(id);
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
            var newDriver = await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();
            return Ok(newDriver);

        }
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            await _unitOfWork.Drivers.Delete(driver);
            await _unitOfWork.CompleteAsync();
            return NoContent();

        }
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, Driver request)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);

            if (driver == null)
            {
                return NotFound();
            }

            await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();

            return Ok(driver);
        }


    }
}

//
