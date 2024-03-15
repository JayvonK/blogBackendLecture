using blockBackend.Models.DTO;
using blockBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace blockBackend.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly UserService _data;

        public UserController(UserService data){
            _data = data;
        }
        
        //Login Endpoint

        //Add User Endpoint
            //if user already exists
            //if user does not exist, create new account
            //else return false

            [HttpPost]
            [Route("AddUser")]
            public bool AddUser(CreateAccountDTO UserToAdd) {
                return _data.AddUser(UserToAdd);
            }

        //Update User Endpiont

        //Delete User Endpoint

    }
