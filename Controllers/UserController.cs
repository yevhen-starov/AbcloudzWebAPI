using AbcloudzWebAPI.DTO;
using AbcloudzWebAPI.Services.Interfaces;
using AbcloudzWebAPI.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AbcloudzWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserValidator _userValidator;
    private readonly IUserService _userService;

    public UserController(
        ILogger<UserController> logger,
        IUserService userService)
    {
        _logger = logger;
        _userValidator = new UserValidator();
        _userService = userService;
    }

    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get()
    {
        var users = await _userService.GetAsync();
        if (users.Any())
        {
            return Ok(users);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] UserDto userDto)
    {
        var validationResult = _userValidator.Validate(userDto);
        if (!validationResult.IsValid)
        {
            var errors = string.Concat(validationResult.Errors.Select(error => error.ErrorMessage));
            throw new FluentValidation.ValidationException($"Validation failed. {errors}");
        }

        var id = await _userService.CreateAsync(userDto);
        
        return Ok(id);
    }
}
