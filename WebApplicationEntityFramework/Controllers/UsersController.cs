using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationEntityFramework.Data;

namespace WebApplicationEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly MyDbContext _context;
        private readonly IUserRepository UserRepository;

        public UsersController(MyDbContext context, IUserRepository userRepository)
        {
            //_context = context;
            this.UserRepository = userRepository; //new UserRepository(context);
        }

        // GET api/users
        [HttpGet]
        public ActionResult Get([FromQuery]int? pageSize, [FromQuery]int? page)
        {
            try
            {
                var eldest = BusinessLogic.GetEldest(UserRepository.GetAllUsers());

                if (pageSize == null)
                {
                    var result = this.UserRepository.GetAllUsers().Select(u => new
                    {
                        u.IdValue,
                        u.Name,
                        u.Gender,
                        u.Email,
                        u.BirthDate,
                        u.Uuid,
                        u.UserName,
                        IsEldest = (eldest.IdValue == u.IdValue),
                        u.Location
                    }).OrderBy(u => u.Name);

                    return Ok(result.ToList());
                }
                else
                {
                    var users = this.UserRepository.GetAllUsers().OrderBy(u => u.Name).Select(u => new {
                        u.IdValue,
                        u.Name,
                        u.Gender,
                        u.Email,
                        u.BirthDate,
                        u.Uuid,
                        u.UserName,
                        IsEldest = (eldest.IdValue == u.IdValue),
                        u.Location
                    });
                    int totalUsers = users.Count();
                    var usersPage = users.Skip(page.Value * pageSize.Value).Take(pageSize.Value);
                    return Ok(new { users = usersPage, totalUsers, page, pageSize });
                }

            }
            catch (Exception)
            {
                return StatusCode(500);                
            }
        }

        //// GET api/users
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {

            try
            {
                var eldest = BusinessLogic.GetEldest(UserRepository.GetAllUsers());

                var user = this.UserRepository.GetUser(id);
                if (user == null)
                    return NotFound();

                return Ok(new
                {
                    user.IdValue,
                    user.Name,
                    user.Gender,
                    user.Email,
                    user.BirthDate,
                    user.Uuid,
                    user.UserName,
                    IsEldest = (eldest.IdValue == user.IdValue),
                    user.Location
                });

            }
            catch (Exception)
            {

                throw;
            }
        }


        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var user = this.UserRepository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                this.UserRepository.DeleteUser(user.IdValue);
            }
            catch (Exception)
            {

                throw;
            }

            return NoContent();
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public IActionResult PutTodoItem(string id, User user)
        {
            if (id != user.IdValue)
            {
                return BadRequest();
            }

            try
            {
                this.UserRepository.UpdateUser(user);
            }
            catch (Exception)
            {

                throw;
            }

            return NoContent();
        }
    }
}
