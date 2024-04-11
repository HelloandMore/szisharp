namespace Solution.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(typeof(GlobalErrorResponse), (int)HttpStatusCode.BadRequest)]
public partial class LoLChampionController(ILoLChampionService<Champion, int> service) : ControllerBase
{
    [HttpGet]
    [Route("/api/lol-champion/get-all")]
    [SwaggerOperation(OperationId = "getAll")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Champion>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Task.FromResult(service.GetAll()));
    }

    [HttpGet]
    [Route("/api/lol-champion/get/{id}")]
    [SwaggerOperation(OperationId = "get")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Champion))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetByid([FromRoute][Required] int id)
    {
        return Ok(await Task.FromResult(service.GetById(id)));
    }

    [HttpDelete]
    [Route("/api/lol-champion/delete/{id}")]
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
    [Route("/api/lol-champion/create")]
    [SwaggerOperation(OperationId = "create")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Champion))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody][Required] Champion requestParam)
    {
        return Ok(service.Create(requestParam));
    }

    [HttpPut]
    [Route("/api/lol-champion/update")]
    [SwaggerOperation(OperationId = "update")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update([FromBody][Required] Champion requestParam)
    {
        service.Update(requestParam);
        return Ok(await Task.FromResult(true));
    }
}
