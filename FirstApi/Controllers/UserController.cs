using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.AddControllers{

    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase{
        private static List<User> UserList = new List<User>(){
            new User{
                Id = 1,
                Name = "Dido",
                SurName = "Hello",
                Password = "asdasd"
            },
            new User{
                Id = 2,
                Name = "Dilo",
                SurName = "Hi",
                Password = "123456"
            }
        };
        [HttpGet]
        public List<User> GetUsers(){
            var userList = UserList.OrderBy(x=>x.Id).ToList<User>();
            return userList;
        }

        [HttpPost]

        public IActionResult AddUser([FromBody] User newUser){
            var user = UserList.SingleOrDefault(x=>x.Id == newUser.Id);

            if(user is not null)
                return BadRequest();
            UserList.Add(newUser);
            return Ok();

        }

        [HttpPut("{id}")]

        public IActionResult UpdateUser(int id,[FromBody] User updatedUser){
            var user = UserList.SingleOrDefault(x=>x.Id == id);

            if(user is null)
                return BadRequest();
            user.Name = updatedUser.Name != default ? updatedUser.Name : user.Name;
            user.SurName = updatedUser.SurName != default ? updatedUser.SurName : user.SurName;
            user.Password = updatedUser.Password != default ? updatedUser.Password : user.Password;

            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteUser(int id){
            var user = UserList.SingleOrDefault(x=>x.Id==id);

            if(user is null)
                return BadRequest();
            
            UserList.Remove(user);
            return Ok();
        }
    }

}