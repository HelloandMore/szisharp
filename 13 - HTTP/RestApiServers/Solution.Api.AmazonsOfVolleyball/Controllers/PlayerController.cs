using Solution.Common.Models.View;

namespace Solution.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(typeof(GlobalErrorResponse), (int)HttpStatusCode.BadRequest)]
public partial class PlayerController(IAmazonsOfVolleyballService<Player, int> service) : ControllerBase
{
    [HttpGet]
    [Route("/api/player/get-all")]
    [SwaggerOperation(OperationId = "getAll")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Player>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Task.FromResult(service.GetAll()));
    }

    [HttpGet]
    [Route("/api/player/get/{id}")]
    [SwaggerOperation(OperationId = "get")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Player))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetByid([FromRoute][Required] int id)
    {
        return Ok(await Task.FromResult(service.GetById(id)));
    }

    [HttpDelete]
    [Route("/api/player/delete/{id}")]
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
    [Route("/api/player/create")]
    [SwaggerOperation(OperationId = "create")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Player))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody][Required] Player requestParam)
    {
        return Ok(service.Create(requestParam));
    }

    [HttpPut]
    [Route("/api/player/update")]
    [SwaggerOperation(OperationId = "update")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update([FromBody][Required] Player requestParam)
    {
        service.Update(requestParam);
        return Ok(await Task.FromResult(true));
    }
}
