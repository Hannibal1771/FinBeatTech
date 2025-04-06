using FinBeatTechAPI.BLL.DTO;
using FinBeatTechAPI.BLL.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FinBeatTechAPI.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        IDefaultService _defaultService;
        ILogger<DefaultController> _logger;
        public DefaultController(IDefaultService defaultService, ILogger<DefaultController> logger)
        {
            _defaultService = defaultService;
            _logger = logger;
        }

        [HttpPost(Name = nameof(GetDefault))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetResponseDTO>> GetDefault([FromBody] GetRequestDTO requestDTO)
        {
            if (requestDTO == null) return BadRequest();

            try
            {
                var (totalRows, resultData) = requestDTO.filterValue == "" || requestDTO.filterValue == null ?
                    await _defaultService.GetDefaultDataAsync(requestDTO):
                    await _defaultService.GetDefaultDataAsync(requestDTO, data => data.Value.Contains(requestDTO.filterValue));

                if (resultData == null) return Problem();


                return Ok(new GetResponseDTO { defaultList = resultData.ToList(), TotalRows = totalRows });
            }
            catch (Exception ex)
            {
                _logger.LogError(HttpContext.Request.Path + ": " + ex.Message);

                return Problem();
            }
        }

        [HttpPost(Name = nameof(CreateDefault))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDefault([FromBody] IEnumerable<CreateRequestDTO> requestDTOsList)
        {
            try
            {
                if (requestDTOsList == null) return BadRequest();

                await _defaultService.CreateDefaultDataAsync(requestDTOsList);
            }
            catch (Exception ex)
            {
                _logger.LogError(HttpContext.Request.Path + ": " + ex.Message);

                return Problem();
            }

            return Ok();
        }
    }
}
