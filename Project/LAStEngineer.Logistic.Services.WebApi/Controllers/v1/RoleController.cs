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
  public class RoleController : Controller
  {

    private readonly IRoleApplication _roleApplication;

    public RoleController(IRoleApplication roleApplication)
    {
      _roleApplication = roleApplication;
    }

    #region "Métodos Sincronos"

    [HttpPost("Insert")]
    public IActionResult Insert([FromBody] RoleDTO roleDto)
    {
      if (roleDto == null)
        return BadRequest();
      var response = _roleApplication.Insert(roleDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] RoleDTO roleDto)
    {
      if (roleDto == null)
        return BadRequest();
      var response = _roleApplication.Update(roleDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpDelete("Delete/{Id}")]
    public IActionResult Delete(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = _roleApplication.Delete(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("Get/{Id}")]
    public IActionResult Get(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = _roleApplication.Get(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
      var response = _roleApplication.GetAll();
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }
    #endregion

    #region "Métodos Asincronos"

    [HttpPost("InsertAsync")]
    public async Task<IActionResult> InsertAsync([FromBody] RoleDTO roleDto)
    {
      if (roleDto == null)
        return BadRequest();
      var response = await _roleApplication.InsertAsync(roleDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync([FromBody] RoleDTO roleDto)
    {
      if (roleDto == null)
        return BadRequest();
      var response = await _roleApplication.UpdateAsync(roleDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpDelete("DeleteAsync/{Id}")]
    public async Task<IActionResult> DeleteAsync(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = await _roleApplication.DeleteAsync(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("GetAsync/{Id}")]
    public async Task<IActionResult> GetAsync(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = await _roleApplication.GetAsync(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
      var response = await _roleApplication.GetAllAsync();
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    #endregion
  }
}