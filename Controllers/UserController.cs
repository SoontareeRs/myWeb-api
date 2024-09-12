using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using MyWebAPI.Services;

namespace MyWebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    public IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        return Ok(await _userService.CreateUser(user));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await _userService.GetAllUsers());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        if (User == null)
        {
            return NotFound();
        }
        return Ok(await _userService.GetUserById(id));
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user){
        return Ok(await _userService.UpdateUserAsync(id, user));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        return Ok(await _userService.DeleteUserAsync(id));
    }
   
}