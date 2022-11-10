using Microsoft.AspNetCore.Mvc;
using WebApiTasks.Data;
using WebApiTasks.Models;

namespace WebApiTasks.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            // check if already exists
            var findUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (findUser != null) return BadRequest("Email already taken");

            findUser = _context.Users.FirstOrDefault(u => u.Uid == user.Uid);
            if (findUser != null) return BadRequest("This ID already exists");

            _context.Add(user);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult Login(LoginModel login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == login.Email);
            if (user == null || user.Password != login.Password) return BadRequest("Invalid credentials");

            var session = new SessionModel()
            {
                Email = user.Email
            };

            var findSession = _context.Sessions.FirstOrDefault(s => s.Token == session.Token);
            if (findSession != null) return BadRequest("This token already exists");

            _context.Add(session);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(session);
        }
    }
}
