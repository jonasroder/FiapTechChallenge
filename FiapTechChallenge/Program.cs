using Application.SharedKernel.Extensions;
using Infrastructure.SharedKernel.Extensions;
using Infrastructure.SharedKernel.Middleware;
using Infrastructure.SharedKernel.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// opcional: carrega um JSON extra
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
       .AddInfrastructure(builder.Configuration)
       .AddApplicationServices();

// 1) registra as configurações de JwtSettings
builder.Services.Configure<JwtSettings>(
  builder.Configuration.GetSection("JwtSettings")
);

// 2) registra o gerador de token
builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

// 3) configura autenticação JWT
builder.Services
  .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(opts =>
  {
      var jwt = builder.Configuration.GetSection("JwtSettings")
                       .Get<JwtSettings>();
      opts.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,
          ValidIssuer = jwt.Issuer,
          ValidateAudience = true,
          ValidAudience = jwt.Audience,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(
                                       Encoding.UTF8.GetBytes(jwt.Secret))
      };
  });
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CorrelationMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
