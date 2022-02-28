using Medco_backend.Models;
using MedcoDBcontext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                var email = userObj.Email;
                var userDetails = _context.Users.Where(x => x.Email == email);
                var user = _context.Users.Where(a =>
                a.Email == userObj.Email
                && a.Password == userObj.Password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(userDetails);
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
