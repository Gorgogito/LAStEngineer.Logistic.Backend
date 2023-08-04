using LAStEngineer.Logistic.Application.Interface.UseCases.Main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LAStEngineer.Logistic.Services.WebApi.Controllers.v1
{

  [Authorize]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [ApiVersion("1.0", Deprecated = false)]
  public class StatusController : Controller
  {

    private readonly IStatusApplication _entityApplication;

    public StatusController(IStatusApplication entityApplication)
    { _entityApplication = entityApplication; }


    #region "Métodos Sincronos"
    
    [HttpGet("Get/{Id}")]
    public IActionResult Get(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = _entityApplication.Get(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
      var response = _entityApplication.GetAll();
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }
    #endregion

    #region "Métodos Asincronos"

    [HttpGet("GetAsync/{Id}")]
    public async Task<IActionResult> GetAsync(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = await _entityApplication.GetAsync(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
      var response = await _entityApplication.GetAllAsync();
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    #endregion

  }
}
