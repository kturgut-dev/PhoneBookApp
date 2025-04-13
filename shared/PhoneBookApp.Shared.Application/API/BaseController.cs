using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Shared.Application.Abstract;
using PhoneBookApp.Shared.Core.Abstract;
using PhoneBookApp.Shared.Core.Utilities.Result;

namespace PhoneBookApp.Shared.Application.API
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TModel, TCreateRequest, TUpdateRequest, TResponse>(
       IBaseService<TModel, TCreateRequest, TUpdateRequest, TResponse> _service)
       : ControllerBase
       where TModel : class, IEntity<Guid>
    {

        [NonAction]
        public IActionResult ReturnResult(Result result)
        {
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [NonAction]
        public IActionResult ReturnResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }


        [HttpPost]
        public virtual async Task<IActionResult> Add([FromBody] TCreateRequest request, CancellationToken cancellationToken)
        {
            Result<TResponse> result = await _service.AddAsync(request, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] TUpdateRequest request, CancellationToken cancellationToken)
        {
            Result result = await _service.UpdateAsync(request, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:guid}")]
        public virtual async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            Result result = await _service.DeleteAsync(id, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:guid}")]
        public virtual async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            Result<TResponse?> result = await _service.GetByIdAsync(id, cancellationToken);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            Result<List<TResponse>> result = await _service.GetAllAsync(cancellationToken);
            return Ok(result);
        }
    }
}
