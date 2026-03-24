using Microsoft.AspNetCore.Mvc;
using System;
using BCrypt.Net;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace MyApi.Controllers
{
    

public class DataModel
{
    public string Name{get;set;}
    public string Email{get;set;}
    public string Password{get;set;}
    public DataModel(string name,string email,string password)
    {
        Name=name;
        Email=email;
        Password=password;
    }
}

public class RegisterRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class LoginRequest
    {
        public string Email{get;set;}
        public string Password{get;set;}
    }

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    public static List<DataModel>data=new List<DataModel>();

    [HttpPost("create")]
    public IActionResult CreateUser([FromBody] RegisterRequest request)
    {
        bool containsEmail=data.Any(e=>e.Email==request.Email);
        if (containsEmail)
        {
            return BadRequest("Email already exist");
        }
        if (request.Password != request.ConfirmPassword)
        {
            return BadRequest("Passwords do not match");
        }

        string hashedPassword=BCrypt.Net.BCrypt.HashPassword(request.Password);

        data.Add(new DataModel(request.Name,request.Email,hashedPassword));
        return Ok("data added");

    }
    
   [HttpPost("login")]
public IActionResult Login([FromBody] LoginRequest request)
{
    var user = data.FirstOrDefault(x => x.Email == request.Email);

    if (user == null)
        return BadRequest("User not found");

    bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

    if (!isValid)
        return BadRequest("Invalid password");

    var token = GenerateToken(user.Email);

    return Ok(new
    {
        message = "Login successful",
        token = token
    });
}

    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(data);
    }

    private string GenerateToken(string email)
        {
            var claims=new[]
            {
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.Name,email)
            };

            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("uihfrewhfrehwfgherwhjevrwgfbherwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrwrw"));
            var cred=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token=new JwtSecurityToken(
               issuer: "MyApi",
        audience: "MyApiUsers",
        claims: claims,
        expires: DateTime.Now.AddHours(1),
        signingCredentials: cred
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

}
}