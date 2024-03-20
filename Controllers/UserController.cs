using blockBackend.Models;
using blockBackend.Models.DTO;
using blockBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace blockBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly UserService _data;

    public UserController(UserService data)
    {
        _data = data;
    }

    //Login Endpoint
    [HttpPost]
    [Route("Login")]
    public IActionResult Login([FromBody] LoginDTO User)
    {
        return _data.Login(User);
    }

    //Add User Endpoint
    //if user already exists
    //if user does not exist, create new account
    //else return false

    [HttpPost]
    [Route("AddUser")]
    public bool AddUser(CreateAccountDTO UserToAdd)
    {
        return _data.AddUser(UserToAdd);
    }

    //Update User Endpiont
    [HttpPut]
    [Route("UpdateUser")]

    public bool UpdateUser(UserModel userToUpdate)
    {
        return _data.UpdateUser(userToUpdate);
    }

    [HttpPut]
    [Route("UpdateUser/{id}/{username}")]
    public bool UpdateUser(int id, string username)
    {
        return _data.UpdateUsername(id, username);
    }

    //Delete User Endpoint
    [HttpDelete]
    [Route("DeleteUser/{userToDelete}")]
    public bool DeleteUser(string userToDelete)
    {
        return _data.DeleteUser(userToDelete);
    }

    [HttpGet]
    [Route("GetUserByUsername/{username}")]
    public UserIdDTO GetUserByUsername(string username){
        return _data.GetUserIdDTOByUsername(username);
    }

}
