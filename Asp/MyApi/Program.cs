using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder=WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


var key=builder.Configuration["Jwt:key"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options=>
{
    options.TokenValidationParameters=new TokenValidationParameters
    {
          ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});

var app=builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();