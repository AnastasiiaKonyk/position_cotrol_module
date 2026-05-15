using backend.Position.Module.API.Swagger;
using backend.Position.Module.API.Auth;
using backend.Position.Module.BLL;
using backend.Position.Module.BLL.Map;
using backend.Position.Module.DAL;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

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

            //// Генеруємо нову пару RSA ключів
            //using var rsa = RSA.Create(2048);
            //var privateKey = rsa.ToXmlString(true);  // Для AuthController
            //var publicKey2 = rsa.ToXmlString(false); // Для appsettings.json

            //// Створюємо токен, підписаний цим приватним ключем
            //var securityKey = new RsaSecurityKey(rsa);
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256);

            //var header = new JwtHeader(credentials);
            //var payload = new JwtPayload
            //{
            //    { "name", "AdminUser" },
            //    { "role", "Administrator" },
            //    { "exp", DateTimeOffset.UtcNow.AddDays(7).ToUnixTimeSeconds() } // Діє 7 днів
            //};

            //var secToken = new JwtSecurityToken(header, payload);
            //var handler = new JwtSecurityTokenHandler();
            //var tokenString = handler.WriteToken(secToken);

            //Console.WriteLine("===============================================================");
            //Console.WriteLine("--- ПРИВАТНИЙ КЛЮЧ (AuthController) ---");
            //Console.WriteLine(privateKey);
            //Console.WriteLine("\n--- ПУБЛІЧНИЙ КЛЮЧ (appsettings.json) ---");
            //Console.WriteLine(publicKey2);
            //Console.WriteLine("\n--- ГОТОВИЙ JWT ТОКЕН (Swagger/LocalStorage) ---");
            //Console.WriteLine(tokenString);
            //Console.WriteLine("===============================================================");



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
            services.AddSwaggerGen();
            services.AddCors();
        }

        public void Configure(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            //app.UseCors(options => options.WithOrigins("*").WithHeaders("*").WithMethods("*"));

            app.UseCors(options => options
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());

            app.UseMiddleware<TokenAddingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}