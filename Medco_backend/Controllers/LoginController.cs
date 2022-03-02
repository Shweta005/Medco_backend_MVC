
using Medco_backend.Helper;
using Medco_backend.Models;
using MedcoDBcontext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;



namespace Medco_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MedcoDBContext _context;
        
        public LoginController(MedcoDBContext context)
        {
            _context = context;
        }
    
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
        var userDetails = _context.Users.AsQueryable();
        return Ok(userDetails);
        }

        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                //string passwordHash = BCrypt.Net.BCrypt.HashPassword(userObj.Password);
                //userObj.Password = EncDscPassword.EncryptPassword(userObj.Password);
                _context.Users.Add(userObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "User Added Successfully"
                });
            }


        }

       

        [HttpPost("login")] 
        public IActionResult Login([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {

                //var user = _context.Users.Where(a => a.Email == userObj.Email).FirstOrDefault();

                var email = userObj.Email;
                var pass = userObj.Password;
                //string Hash = BCrypt.Net.BCrypt.HashPassword(pass);
                //var user = _context.Users.Where(x => x.Email == email && x.Password == Hash).FirstOrDefault();
                //var userDetails = _context.Users.Where(x => x.Email == email);
                var user = _context.Users.Where(x => x.Email == email && x.Password == pass).FirstOrDefault();
                //var details = _context.Users.Where(User =>
                //User.Email == email
                //&& EncDscPassword.DecryptPassword(User.Password) == pass).FirstOrDefault();

                //a.Password == userObj.Password).FirstOrDefault();
               
                if (user!=null)
                {
                    
                    return Ok(user);
                }

                else
                {
                    return NotFound(new
                    {
                       
                        Statuscode = 404,
                        Message = "User not found"
                    });
                }
            }
        }
    }
}
