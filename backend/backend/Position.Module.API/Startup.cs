using backend.Position.Module.API.Swagger;
using backend.Position.Module.API.Auth;
using backend.Position.Module.BLL;
using backend.Position.Module.BLL.Map;
using backend.Position.Module.DAL;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace backend.Position.Module.API
{
    public class Startup
    {
        private readonly IConfiguration _configRoot;

        public Startup(IConfiguration configuration)
        {
            _configRoot = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

    //        // 1. Створюємо абсолютно новий ключ у пам'яті
    //        using var rsa = System.Security.Cryptography.RSA.Create(2048);

    //        // 2. Отримуємо ПУБЛІЧНИЙ ключ для appsettings.json (скопіюйте його з консолі!)
    //        Console.WriteLine("--- ПУБЛІЧНИЙ КЛЮЧ ДЛЯ appsettings.json ---");
    //        Console.WriteLine(rsa.ToXmlString(false));
    //        Console.WriteLine("-------------------------------------------");

    //        var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
    //        var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
    //        {
    //            Subject = new System.Security.Claims.ClaimsIdentity(new[] {
    //    new System.Security.Claims.Claim("name", "Admin")
    //}),
    //            Expires = DateTime.UtcNow.AddDays(1),
    //            SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
    //                new Microsoft.IdentityModel.Tokens.RsaSecurityKey(rsa),
    //                Microsoft.IdentityModel.Tokens.SecurityAlgorithms.RsaSha256)
    //        };

    //        var token = handler.CreateToken(tokenDescriptor);
    //        var tokenString = handler.WriteToken(token);

    //        Console.WriteLine("--- SWAGGER (eyJ...) ---");
    //        Console.WriteLine(tokenString);
    //        Console.WriteLine("---------------------------------------");

            //using var rsa = System.Security.Cryptography.RSA.Create(2048);
            //var privateKeyXml = rsa.ToXmlString(true);
            //Console.WriteLine(privateKeyXml);
            //var xmlKey = rsa.ToXmlString(false);
            //Console.WriteLine();
            //Console.WriteLine(xmlKey);

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(_configRoot.GetSection("Logging"));
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Information);
                loggingBuilder.AddDebug();
            });

            services.AddDataAccess(_configRoot);
            services.AddBusinessLogic(null!, _configRoot);
            services.AddAutoMapper(typeof(TypePosadMapping));

            var publicKey = _configRoot.GetSection("Jwt:PublicKey").Value;
            if (!string.IsNullOrEmpty(publicKey))
            {
                services.AddTokenAuthentication(publicKey);
            }

            services.AddSwaggerOptions();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ваш API", Version = "v1" });

                // Додаємо опис схеми безпеки
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Введіть токен у форматі: Bearer {ваш_токен}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            services.AddCors();
        }

        public void Configure(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(options => options.WithOrigins("*").WithHeaders("*").WithMethods("*"));

            app.UseMiddleware<TokenAddingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}