using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using backend.Position.Module.BLL.Services.Interfaces;
using System.Security.Authentication;
using backend.Position.Module.BLL.Dtos;

namespace backend.Position.Module.API.Controllers
{
    public class TypePosadController : BaseController<TypePosadController>
    {
        private readonly ITypePosadService _typePosadService;

        public TypePosadController(
            IMapper mapper,
            ILogger<TypePosadController> logger,
            ITypePosadService typePosadService)
            : base(mapper, logger)
        {
            _typePosadService = typePosadService;
        }

        // -----------------------------------------------------------------
        // 1. ОТРИМАННЯ ПОСАД З ПАГІНАЦІЄЮ ТА СОРТУВАННЯМ
        // GET api/typeposad
        // -----------------------------------------------------------------
        [HttpGet]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPaged(
            [FromQuery] bool includeArchive = false,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Name",
            [FromQuery] bool sortDescending = false)
        {
            try
            {
                _logger.LogInformation("Retrieving paged TypePosads. Page: {PageNumber}, Size: {PageSize}", pageNumber, pageSize);

                var (items, totalCount) = await _typePosadService.GetPagedAsync(
                    includeArchive, pageNumber, pageSize, sortBy, sortDescending);

                return Ok(new { items, totalCount });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving paged TypePosads.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // -----------------------------------------------------------------
        // 2. ОТРИМАННЯ ПОСАДИ ЗА ID
        // GET api/typeposad/5
        // -----------------------------------------------------------------
        [HttpGet("{id:int}", Name = "GetById")]
        [ProducesResponseType(typeof(TypePosadDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _typePosadService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound($"Position with ID {id} not found.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving TypePosad with ID: {Id}", id);
                return StatusCode(500, "Internal server error.");
            }
        }
        

        // -----------------------------------------------------------------
        // 3. СТВОРЕННЯ ПОСАДИ
        // POST api/typeposad
        // -----------------------------------------------------------------
        [HttpPost]
        [ProducesResponseType(typeof(TypePosadDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromBody] CreateTypePosadDto dto)
        {
            if (dto == null) return BadRequest("Data cannot be null.");

            try
            {
                _logger.LogInformation("Creating new TypePosad: {Name}", dto.Name);

                var createdId = await _typePosadService.CreateAsync(dto);

                // Отримуємо створений об'єкт для повернення результату
                var createdObject = await _typePosadService.GetByIdAsync(createdId);

                return CreatedAtAction(nameof(GetById), new { id = createdId }, createdObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating TypePosad.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // -----------------------------------------------------------------
        // 4. ОНОВЛЕННЯ ПОСАДИ
        // PUT api/typeposad/5
        // -----------------------------------------------------------------
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] TypePosadDto dto)
        {
            dto.Id = id;
            if (dto == null) return BadRequest();

            try
            {
                _logger.LogInformation("Updating TypePosad ID: {Id}", id);

                var success = await _typePosadService.UpdateAsync(dto);
                if (!success) return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating TypePosad ID: {Id}", id);
                return StatusCode(500, "Internal server error.");
            }
        }

        // -----------------------------------------------------------------
        // 5. ЗМІНА СТАТУСУ (АКТИВАЦІЯ/АРХІВАЦІЯ)
        // PATCH api/typeposad/5/status?active=true
        // -----------------------------------------------------------------
        [HttpPatch("{id:int}/status")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> SetStatus(int id, [FromQuery] bool active)
        {
            try
            {
                _logger.LogInformation("Changing status for TypePosad ID: {Id} to Active={Active}", id, active);

                var success = await _typePosadService.SetStatusAsync(id, active);
                if (!success) return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error changing status for TypePosad ID: {Id}", id);
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}