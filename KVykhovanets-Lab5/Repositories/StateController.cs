using Microsoft.AspNetCore.Mvc;
using KVykhovanets_Lab5.Models.TableModels;
using KVykhovanets_Lab5.Repositories;

namespace KVykhovanets_Lab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository repo;

        public StateController(IStateRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<States>))]
        public async Task<IEnumerable<States>> GetStates()
        {
            return await repo.RetrieveAllAsync();
        }

        [HttpGet("{id}", Name = nameof(GetState))]
        [ProducesResponseType(200, Type = typeof(States))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetState(int id)
        {
            States? state = await repo.RetrieveAsync(id);
            if (state == null) return NotFound();
            return Ok(state);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(States))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] States state)
        {
            if (state == null) return BadRequest();

            States? created = await repo.CreateAsync(state);
            if (created == null) return BadRequest("Failed to create state.");

            return CreatedAtRoute(nameof(GetState), new { id = created.StateID }, created);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] States state)
        {
            if (state == null || state.StateID != id) return BadRequest();

            var updated = await repo.UpdateAsync(id, state);
            if (updated == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await repo.DeleteAsync(id);
            if (deleted == null || deleted == false) return NotFound();

            return NoContent();
        }
    }
}