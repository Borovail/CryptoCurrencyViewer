using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Views.Authorization;
using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CryptoCurrencyViewer.Controllers;

public class AuthorizationController : Controller
{

   private readonly IDbService _dbService;
    private readonly IConfiguration _configuration;

    public AuthorizationController(IDbService dbService, IConfiguration configuration   ) 
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
    [HttpPost]
    public async Task<IActionResult> LoginUser([FromBody] UserModel user)
    {
        var userFromDb = await _dbService.GetItemByEmailAsync<UserModel>(user.Email);

        if (userFromDb == null)
        {
            return Unauthorized(new { message = "Account not registered or credentials are incorrect" });
        }

        var hashedPassword = AppHelper.HashPassword(user.Password);

        if (hashedPassword != userFromDb.Password)
        {
            return Unauthorized(new { message = "Incorrect password." });
        }

        return Ok(new { token = GenerateJwtToken(user.Email, userFromDb.Id) });
    }


    /// <summary>
    /// try to add user  if succes return ok
    /// else catch  db exception or expectionn and return fail code
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] UserModel user)
    {

        if (!ModelState.IsValid)
        {
            var errors = ModelState
         .Where(e => e.Value.Errors.Count > 0)
         .ToDictionary(
             e => e.Key,
             e => e.Value.Errors.Select(er => er.ErrorMessage).ToArray()
         );

            return BadRequest(new { errors });
        }

        try
        {
            user.Password= AppHelper.HashPassword(user.Password);
            await _dbService.AddItemAsync(user);
            return Ok();
        }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
        {
            // Это пример, который перехватывает исключения SQL, связанные с нарушениями ограничения уникальности
            return BadRequest(new { message = "User already exists or duplicate data provided." });
        }
        catch (DbUpdateException)
        {
            // Для других ошибок обновления базы данных отправляем обобщенное сообщение
            return BadRequest(new { message = "Invalid data provided, please check your input and try again." });
        }
        catch (Exception)
        {
            // Для всех остальных исключений отправляем обобщенное сообщение
            return StatusCode(500, new { message = "An error occurred while processing your request, please try again later." });
        }
    }


   /// <summary>
   /// generate jtw token after succesfull login   ///called by
   /// </summary>
   private string GenerateJwtToken(string email,int id)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { 
                new Claim(ClaimTypes.Email, email) ,
                new Claim(ClaimTypes.NameIdentifier, id.ToString()) // Добавление ID пользователя как claim
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"]
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

   


}



