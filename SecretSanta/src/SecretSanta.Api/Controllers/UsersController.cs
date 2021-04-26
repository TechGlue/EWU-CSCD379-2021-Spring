using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using SecretSanta.Data;
using SecretSanta.Business;

namespace SecretSanta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository UserManager{get;}
        
        public UsersController(IUserRepository userManager)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        //https://localhost:5101/api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return UserManager.List();
        }

        [HttpGet("{id}")]
        public ActionResult<User?> Get(int id){
            if(id < 0)
            {
                return NotFound();
            }

            User? returnedUser = UserManager.GetItem(id);
            return returnedUser;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(id < 0)
            {
                return NotFound();
            }
            if(UserManager.Remove(id))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<User?> Post([FromBody] User? myUser)
        {
            if(myUser is null)
            {
                return BadRequest();
            }

            return UserManager.Create(myUser);
        }

        // [HttpPut("{id}")]
        // public ActionResult Put(int id, ){
        //     if(updatedUser is null)
        //     {
        //         return BadRequest();
        //     }
        //     User? foundUser = UserManager.GetItem(id);
        //     if(foundUser is not null){
        //         if(!string.IsNullOrWhiteSpace(updatedUser.fir))
        //     }

        // }



    }
}
