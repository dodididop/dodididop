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
    }

}