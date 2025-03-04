using Microsoft.AspNetCore.Mvc;

namespace BackAgente.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class MyApiController : ControllerBase
        {
            // GET: api/myapi
            [HttpGet]
            public IActionResult Get()
            {
                var data = new { Message = "Hello from the backend!" };
                return Ok(data);
            }

            // GET: api/myapi/5
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var data = new { Id = id, Message = "This is your data." };
                return Ok(data);
            }

            // POST: api/myapi
            [HttpPost]
            public IActionResult Post([FromBody] object newItem)
            {
                // Procesa el objeto recibido
                return CreatedAtAction(nameof(GetById), new { id = 1 }, newItem);
            }

            // PUT: api/myapi/5
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] object updatedItem)
            {
                // Actualiza el objeto con el id correspondiente
                return NoContent();
            }

            // DELETE: api/myapi/5
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                // Elimina el objeto con el id correspondiente
                return NoContent();
            }
    }
}
