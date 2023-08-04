using LAStEngineer.Logistic.Application.DTO.Objects.Main;
using LAStEngineer.Logistic.Application.Interface.UseCases.Main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LAStEngineer.Logistic.Services.WebApi.Controllers.v1
{

  [Authorize]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [ApiVersion("1.0", Deprecated = false)]
  public class Role_x_CompanyController : Controller
  {

    private readonly IRole_x_CompanyApplication _entityApplication;

    public Role_x_CompanyController(IRole_x_CompanyApplication entityApplication)
    { _entityApplication = entityApplication; }

    #region "Métodos Sincronos"

    [HttpPost("Insert")]
    public IActionResult Insert([FromBody] Role_x_CompanyDTO entityDto)
    {
      if (entityDto == null)
        return BadRequest();
      var response = _entityApplication.Insert(entityDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Role_x_CompanyDTO entityDto)
    {
      if (entityDto == null)
        return BadRequest();
      var response = _entityApplication.Update(entityDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpDelete("Delete")]
    public IActionResult Delete([FromQuery] string roleId, [FromQuery] string companyId)
    {
      if (string.IsNullOrEmpty(roleId) || string.IsNullOrEmpty(companyId))
        return BadRequest();
      var response = _entityApplication.Delete(roleId, companyId);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("Get")]
    public IActionResult Get([FromQuery] string roleId, [FromQuery] string companyId)
    {
      if (string.IsNullOrEmpty(roleId) || string.IsNullOrEmpty(companyId))
        return BadRequest();
      var response = _entityApplication.Get(roleId, companyId);
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
    public async Task<IActionResult> InsertAsync([FromBody] Role_x_CompanyDTO entityDto)
    {
      if (entityDto == null)
        return BadRequest();
      var response = await _entityApplication.InsertAsync(entityDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync([FromBody] Role_x_CompanyDTO entityDto)
    {
      if (entityDto == null)
        return BadRequest();
      var response = await _entityApplication.UpdateAsync(entityDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpDelete("DeleteAsync")]
    public async Task<IActionResult> DeleteAsync([FromQuery] string roleId, [FromQuery] string companyId)
    {
      if (string.IsNullOrEmpty(roleId) || string.IsNullOrEmpty(companyId))
        return BadRequest();
      var response = await _entityApplication.DeleteAsync(roleId, companyId);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("GetAsync")]
    public async Task<IActionResult> GetAsync([FromQuery] string roleId, [FromQuery] string companyId)
    {
      if (string.IsNullOrEmpty(roleId) || string.IsNullOrEmpty(companyId))
        return BadRequest();
      var response = await _entityApplication.GetAsync(roleId, companyId);
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
