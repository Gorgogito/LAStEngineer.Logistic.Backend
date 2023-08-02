using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Application.Interface.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LAStEngineer.Logistic.Services.WebApi.Controllers.v1
{

  [Authorize]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [ApiVersion("1.0", Deprecated = false)]
  public class UserController : Controller
  {

    private readonly IUserApplication _entityApplication;

    public UserController(IUserApplication entityApplication)
    {
      _entityApplication = entityApplication;
    }

    #region "Métodos Sincronos"

    [HttpPost("Insert")]
    public IActionResult Insert([FromBody] UserDTO entityDto)
    {
      if (entityDto == null)
        return BadRequest();
      var response = _entityApplication.Insert(entityDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] UserDTO entityDto)
    {
      if (entityDto == null)
        return BadRequest();
      var response = _entityApplication.Update(entityDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpDelete("Delete/{Id}")]
    public IActionResult Delete(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = _entityApplication.Delete(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

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

    [HttpPost("InsertAsync")]
    public async Task<IActionResult> InsertAsync([FromBody] UserDTO entityDto)
    {
      if (entityDto == null)
        return BadRequest();
      var response = await _entityApplication.InsertAsync(entityDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync([FromBody] UserDTO entityDto)
    {
      if (entityDto == null)
        return BadRequest();
      var response = await _entityApplication.UpdateAsync(entityDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpDelete("DeleteAsync/{Id}")]
    public async Task<IActionResult> DeleteAsync(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = await _entityApplication.DeleteAsync(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

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
