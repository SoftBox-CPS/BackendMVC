using Microsoft.AspNetCore.Mvc;

namespace MVCWebApplication.Controllers.Base;

public abstract class EntityController<T, B> : ViewController where T : SoftBox.DataBase.InterfacesEntities.IEntity<B>
{
    protected readonly SoftBox.DataBase.InterfacesRepository.Base.IRepository<T, B> repository;

    protected EntityController(SoftBox.DataBase.InterfacesRepository.Base.IRepository<T, B> repository)
    {
        this.repository = repository;
    }

    [HttpGet("count")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> GetItemsCount()
    {
        return Ok(await repository.GetCount());
    }

    [HttpPost("exist")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
    public async Task<IActionResult> Exist(T item)
    {
        return await repository.Exist(item) ? Ok(true) : NotFound(false);
    }

    [HttpGet("getAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await repository.GetAll());
    }

    [HttpGet("items[[{Skip:int}:{Count:int}]]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<T>>> Get(int Skip, int Count)
    {
       return Ok(await repository.Get(Skip, Count));
    }

    [HttpGet("{id}")]
    [ActionName("Get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(B id)
    {

       return await repository.GetById(id) is { } item
            ? Ok(item)
            : NotFound();
    }

    [HttpPost("item")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Add(T item)
    {
        var result = await repository.Add(item);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("item")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(T item)
    {
        if (await repository.Update(item) is not { } result)
            return NotFound(item);
        return AcceptedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpDelete("item")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(T item)
    {
        if (await repository.Delete(item) is not { } result)
            return NotFound(item);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteById(B id)
    {
        if (await repository.DeleteById(id) is not { } result)
            return NotFound(id);
        return Ok(result);
    }
}
