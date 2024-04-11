namespace Solution.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(typeof(GlobalErrorResponse), (int)HttpStatusCode.BadRequest)]
public partial class DigimonController(IDigimonServiceService<Digimon, int> service) : ControllerBase
{
    [HttpGet]
    [Route("/api/digimon/get-all")]
    [SwaggerOperation(OperationId = "getAll")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Digimon>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Task.FromResult(service.GetAll()));
    }

    [HttpGet]
    [Route("/api/digimon/get/{id}")]
    [SwaggerOperation(OperationId = "get")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Digimon))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetByid([FromRoute][Required] int id)
    {
        return Ok(await Task.FromResult(service.GetById(id)));
    }

    [HttpDelete]
    [Route("/api/digimon/delete/{id}")]
    [SwaggerOperation(OperationId = "delete")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete([FromRoute][Required] int id)
    {
        service.Delete(id);
        return Ok(await Task.FromResult(true));
    }

    [HttpPost]
    [Route("/api/digimon/create")]
    [SwaggerOperation(OperationId = "create")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Digimon))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody][Required] Digimon requestParam)
    {
        return Ok(service.Create(requestParam));
    }

    [HttpPut]
    [Route("/api/digimon/update")]
    [SwaggerOperation(OperationId = "update")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update([FromBody][Required] Digimon requestParam)
    {
        service.Update(requestParam);
        return Ok(await Task.FromResult(true));
    }
}
