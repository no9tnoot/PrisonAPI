using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prisoners.Data.Models;
using Prisoners.Data.Repositories;

namespace Prisoners.Api.Controllers
{
    [Route("api/prisoner")]
    [ApiController]
    public class PrisonController : ControllerBase
    {
        private readonly IPrisonRepository _prisonRepository;
        private readonly ILogger<PrisonController> _logger;
        public PrisonController(IPrisonRepository prisonRepository, ILogger<PrisonController> logger)
        {
            _prisonRepository = prisonRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrisoner(Prisoner prisoner)
        {
            try
            {
                var newPrisoner = await _prisonRepository.AddPrisoner(prisoner);
                return CreatedAtAction(nameof(AddPrisoner), newPrisoner);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = 500,
                    message = ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePrisonerCellNumber(Prisoner prisonerToUpdate)
        {
            try
            {
                var existingPrisoner = await _prisonRepository.GetPrisoner(prisonerToUpdate.Id);
                if (existingPrisoner == null) 
                {
                    return NotFound(new
                    {
                        StatusCode=404,
                        message = "record not found"
                    });
                }
                existingPrisoner.Cellnumber = prisonerToUpdate.Cellnumber;
                await _prisonRepository.AddPrisoner(prisonerToUpdate);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = 500,
                    message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrisoner(int id)
        {
            try
            {
                var existingPrisoner = await _prisonRepository.GetPrisoner(id);
                if (existingPrisoner == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "record not found"
                    });
                }
                await _prisonRepository.DeletePrisoner(existingPrisoner);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = 500,
                    message = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPrisoners()
        {
            try
            {
                var prisoners = await _prisonRepository.GetPrisoners();
               
                return Ok(prisoners);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = 500,
                    message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrisoner(int id)
        {
            try
            {
                var existingPrisoner = await _prisonRepository.GetPrisoner(id);
                if (existingPrisoner == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "record not found"
                    });
                }
                return Ok(existingPrisoner);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = 500,
                    message = ex.Message
                });
            }
        }

        [HttpPost("{id}/inventory")]
        public async Task<IActionResult> AddIventory(Inventory inv)
        {
            try
            {
                var newInv = await _prisonRepository.AddInventory(inv);
                return CreatedAtAction(nameof(AddIventory), newInv);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = 500,
                    message = ex.Message
                });
            }
        }

        [HttpGet("{id}/inventories")]
        public async Task<IActionResult> GetInventory(int id)
        {
            try
            {
                var prisonerInventories = await _prisonRepository.GetInventories(id);
                if (prisonerInventories == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "record not found"
                    });
                }
                return Ok(prisonerInventories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = 500,
                    message = ex.Message
                });
            }
        }
    }
}
