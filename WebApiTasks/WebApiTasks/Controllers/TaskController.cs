using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTasks.Data;
using WebApiTasks.Models;

namespace WebApiTasks.Controllers
{
    [Route("tasks")]
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Create(CreateTaskModel createTask)
        {
            // find email of the user making the request
            var session = _context.Sessions.FirstOrDefault(s => s.Token == createTask.Token);
            if (session == null) return BadRequest("Invalid token");

            // find user with the email
            var user = _context.Users.FirstOrDefault(u => u.Email == session.Email);
            if (user == null) return BadRequest("Invalid session email");

            // find the assigned user
            var assignedUser = _context.Users.FirstOrDefault(u => u.Uid == createTask.AssignedToUid);
            if (assignedUser == null) return BadRequest("Invalid assigned user");

            var task = new TaskModel()
            {
                CreatedByUid = user.Uid,
                CreatedByName = user.Name,
                AssignedToUid = assignedUser.Uid,
                AssignedToName = assignedUser.Name,
                Description = createTask.Description
            };

            _context.Add(task);
            var findTask = _context.Tasks.FirstOrDefault(t => t.TaskUid == task.TaskUid);

            if (findTask != null) 
            {
                return BadRequest("This ID already exists");
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(findTask);
        }

        [HttpGet("createdby")]
        public ActionResult<IEnumerable<TaskModel>> GetTasksCreatedBy(string token)
        {
            // find email of the user making the request
            var session = _context.Sessions.FirstOrDefault(s => s.Token == token);
            if (session == null) return BadRequest("Invalid token");

            // find user with the email
            var user = _context.Users.FirstOrDefault(u => u.Email == session.Email);
            if (user == null) return BadRequest("Invalid session email");

            var tasks = _context.Tasks.Where(task => task.CreatedByUid == user.Uid).ToList();

            if (tasks == null)
            {
                return NotFound("There is no tasks created by this user.");
            }

            return tasks;
        }

        [HttpGet("assignedto")]
        public ActionResult<IEnumerable<TaskModel>> GetTasksAssignedTo(string token)
        {
            // find email of the user making the request
            var session = _context.Sessions.FirstOrDefault(s => s.Token == token);
            if (session == null) return BadRequest("Invalid token");

            // find user with the email
            var user = _context.Users.FirstOrDefault(u => u.Email == session.Email);
            if (user == null) return BadRequest("Invalid session email");

            var tasks = _context.Tasks.Where(task => task.AssignedToUid == user.Uid).ToList();

            if (tasks == null)
            {
                return NotFound("There is no tasks assigned to this user.");
            }

            return tasks;
        }

        [HttpPut("{taskId}")]
        public ActionResult Update(string token, string taskId, TaskModel newTask)
        {
            if (taskId != newTask.TaskUid)
            {
                return BadRequest("Ids do not match");
            }

            // find email of the user making the request
            var session = _context.Sessions.FirstOrDefault(s => s.Token == token);
            if (session == null) return BadRequest("Invalid token");

            // find user with the email
            var user = _context.Users.FirstOrDefault(u => u.Email == session.Email);
            if (user == null) return BadRequest("Invalid session email");

            var task = _context.Tasks.FirstOrDefault(t => t.TaskUid == taskId);
            if (task == null || task.AssignedToUid != user.Uid) return BadRequest("Cannot update this task");

            _context.Entry(newTask).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(newTask);
        }

        [HttpDelete("{taskId}")]
        public ActionResult Delete(string token, string taskId)
        {
            // find email of the user making the request
            var session = _context.Sessions.FirstOrDefault(s => s.Token == token);
            if (session == null) return BadRequest("Invalid token");

            // find user with the email
            var user = _context.Users.FirstOrDefault(u => u.Email == session.Email);
            if (user == null) return BadRequest("Invalid session email");

            var task = _context.Tasks.FirstOrDefault(t => t.TaskUid == taskId);
            if (task == null || task.CreatedByUid != user.Uid) return BadRequest("Cannot delete this task");

            _context.Remove(task);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(task);
        }
    }
}
