using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Views.Authorization;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CryptoCurrencyViewer.Controllers;

public class AuthorizationController : Controller
{

   private readonly IDbService _dbService;
    private readonly IConfiguration _configuration;

    public AuthorizationController(IDbService dbService, IConfiguration configuration) 
    { 
        _dbService = dbService;

        _configuration = configuration;
    }

    /// <summary>
    /// /return form with register form
    /// </summary>
    /// <returns></returns>
    public ActionResult Register()
    {
        return View("Authorization", PageState.Registration);
    }

    /// <summary>
    /// /return form with  login form
    /// </summary>
    /// <returns></returns>
    public ActionResult Login()
    {
        return View("Authorization", PageState.Login);
    }


    /// <summary>
    ///ask to db    if  db has user with email     if yes   check if user has correct password
    ///if no   Unauthorized()    if yes        Ok(new { token = GenerateJwtToken(user.Email) });
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<IActionResult> LoginUser([FromBody]UserModel user)
    {
        var userFromDb = await _dbService.GetItemByEmailAsync<UserModel>(user.Email);

        if(userFromDb == null) return Unauthorized();
        
        var hashedPassword = _dbService.HashPassword(user.Password);

        if(hashedPassword != userFromDb.Password) return Unauthorized();



        return Ok(new { token = GenerateJwtToken(user.Email) });

    }


    /// <summary>
    /// try to add user  if succes return ok
    /// else catch  db exception or expectionn and return fail code
    /// </summary>
    public async Task<IActionResult> RegisterUser([FromBody] UserModel user)
    {
        try
        {
            await _dbService.AddItemAsync(user);

            return Ok();
        }
        catch (DbUpdateException ex)
        {
            // Если ошибка связана с обновлением БД, например, нарушение уникальности
            return BadRequest(new { message = ex.InnerException?.Message ?? ex.Message });
        }
        catch (Exception ex)
        {
            // Для других типов исключений возвращаем InternalServerError
            return StatusCode(500, new { message = ex.Message });
        }

    }


    /// <summary>
    /// generate jtw token after succesfull login   ///called by
    /// </summary>
    public string GenerateJwtToken(string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"]
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}



