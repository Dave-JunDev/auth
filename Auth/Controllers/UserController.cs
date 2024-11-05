using Auth.Interfaces;
using Auth.Model;
using Auth.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly ICommonServices<User> _userService;
    private readonly IPaginationUtil _paginationUtil;
    
    public UserController(
        ILogger<UserController> logger, 
        [FromKeyedServices("UserService")]ICommonServices<User> userService,
        IPaginationUtil paginationUtil
    )
    {
        _logger = logger;
        _userService = userService;
        _paginationUtil = paginationUtil;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetUser(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user.Id == 0)
            return NotFound();
        return Ok(user);
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var users = await _userService.GetAllAsync();
        
        if (users.Count() == 0)
            return NotFound();
        
        return Ok(_paginationUtil.GetPagination(users, page, pageSize));
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser(User user)
    {
        return Ok(await _userService.AddAsync(user));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id, User user)
    {
        if (id != user.Id)
            return BadRequest();
        
        var result = await _userService.UpdateAsync(user);
        
        if (result.Id == 0)
            return NotFound();
        
        return Ok(result);
    }
}