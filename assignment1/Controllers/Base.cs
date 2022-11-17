using assignment1.Business;
using assignment1.Common.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using assignment1.Business;
using System.Threading.Tasks;
using assignment1.Common.Dto;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Base : Controller
    {
        private readonly IUserManager userManager;
        public Base(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        // GET: api/<Base>
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var listOfUsers =  await userManager.GetUsers();
            return Ok(listOfUsers); 
        }
       
        // GET api/<Base>/5
        [HttpPost("Update")]
        public async Task<IActionResult> Update(UserDto dto)
        {
            var (flag, response) = await userManager.UpdateUser(dto);
            if(flag)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        // POST api/<Base>
        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            var (flag, response) = await userManager.AddUser(userDto);
            if (flag)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        // DELETE api/<Base>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var (flag, response) = await userManager.DeleteUser(id);
            if (flag)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
       
    } 
}
