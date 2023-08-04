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
  public class CompanyController : Controller
  {

    private readonly ICompanyApplication _companyApplication;

    public CompanyController(ICompanyApplication companyApplication)
    {
      _companyApplication = companyApplication;
    }

    #region "Métodos Sincronos"

    [HttpPost("Insert")]
    public IActionResult Insert([FromBody] CompanyDTO companyDto)
    {
      if (companyDto == null)
        return BadRequest();
      var response = _companyApplication.Insert(companyDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] CompanyDTO companyDto)
    {
      if (companyDto == null)
        return BadRequest();
      var response = _companyApplication.Update(companyDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpDelete("Delete/{Id}")]
    public IActionResult Delete(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = _companyApplication.Delete(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("Get/{Id}")]
    public IActionResult Get(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = _companyApplication.Get(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
      var response = _companyApplication.GetAll();
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }
    #endregion

    #region "Métodos Asincronos"

    [HttpPost("InsertAsync")]
    public async Task<IActionResult> InsertAsync([FromBody] CompanyDTO companyDto)
    {
      if (companyDto == null)
        return BadRequest();
      var response = await _companyApplication.InsertAsync(companyDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync([FromBody] CompanyDTO companyDto)
    {
      if (companyDto == null)
        return BadRequest();
      var response = await _companyApplication.UpdateAsync(companyDto);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpDelete("DeleteAsync/{Id}")]
    public async Task<IActionResult> DeleteAsync(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = await _companyApplication.DeleteAsync(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("GetAsync/{Id}")]
    public async Task<IActionResult> GetAsync(string Id)
    {
      if (string.IsNullOrEmpty(Id))
        return BadRequest();
      var response = await _companyApplication.GetAsync(Id);
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
      var response = await _companyApplication.GetAllAsync();
      if (response.IsSuccess)
        return Ok(response);

      return BadRequest(response.Message);
    }

    #endregion

  }
}
