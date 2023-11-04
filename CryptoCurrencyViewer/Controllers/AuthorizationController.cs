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
    /// login user can return null    ////   proce=cesing data  in js  ///called by
    /// </summary>
    public IActionResult LoginUser([FromBody]UserModel user)
    {
        ////check if  user registred after  generateToken
        return Ok(new { token = GenerateJwtToken(user.Email) });

        return Unauthorized();

    }


    /// <summary>
    /// add user to db    ///all data validation does in js   ///called by
    /// </summary>
    public void RegisterUser()
    {
        /////register user add to db   if all data correct
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



