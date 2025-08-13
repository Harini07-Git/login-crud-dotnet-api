using Microsoft.AspNetCore.Mvc;
using login_crud_dotnet_api.Models;

namespace login_crud_dotnet_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private static List<User> users = new List<User>()
        {
            new User { Id = 1, Username = "admin", Email = "admin@example.com", Password = "admin123" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            users.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            users.Remove(user);
            return NoContent();
        }
    }
}
