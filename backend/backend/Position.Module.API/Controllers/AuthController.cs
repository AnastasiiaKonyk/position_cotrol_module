using Microsoft.AspNetCore.Mvc;

namespace backend.Position.Module.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("auto-login")]
        public IActionResult GetToken()
        {
            string privateKeyXml = "<RSAKeyValue><Modulus>tcU3MaTRJCaM2W4ENblsbASQF910FASb2sG0b+kjymAgYdccaOA070koGq46slPKh7pD0SBzTMJR+B37aeIvze2oRMJc9LNHmikOfkoymbAfVGRjR+wplkh7vv2LntXH1h1ns50HZ4iipsPNppiXgPOTIYuAEHcas0QiifTLQRTQPYNf65q/Tnb25Jloji6D1nYm7EpK/KSroVWhYjsPvU8Vtt2Oy1iEuW+qu3Ho0lCl933enMy3lyqyw2hqdaptqREsn9JafYZZpOqCPlvkSLNOEFcLobIFU+/HcwpxajKSuzUnnwcTmzDbqz6WAsrektsbmyRHwQHJ8ma49//FRQ==</Modulus><Exponent>AQAB</Exponent><P>0zshexYJwfvLAxWYHMYmmKQ+eKZxgMTIIipS2ggV+K1Jb/Bn1URYPJBI/Qpsa8PucBqeZfl8gI1XXCSl3+UbTp0KF7lqYyc25gqRWNbYvXd47oHWqjLA6zPfj6O0qN82shXUhYZhMv7yCU7ARFHamc9MN0+Nut8BpsBLSnlQTwc=</P><Q>3EugGFyHtxNnZQV6TxWb2HSnzk1QQIxxODgBI9jqD+ujLlgi3fa0vUtB6pYp02hEts3nSm3NJD9zsHIYLCubyaI1Abg0bO46AufzYWLvM1vbRyZSit1dcn7J6gDxjxQuOjE9bNf7A+V0cbDLclQD7cUPqjiAUGGZAFiv0mtJKlM=</Q><DP>OWFnv/MFpY+L34OfNbnSREbhvY6haLSMFVPf++CUb2BLgcARxMpzGcisOyj4uPGZtRRWESeL3bQHlj1SXhbzqxBX7Ifu0Y6WiDk4sKR0bkulK01UDhoJdBs8UN3Mts8kIY5yk+8kOmEtSL/+1NBTjNLWRnQy8R+haDX2ff2khkM=</DP><DQ>xYunf9ER/pEO6d80o9B71WoexHg+G/QU31YRZ6Tvl+E1jqyIb8T4pLrk3ElWLnbVD5yq6Op3yCaCRtq5ZHqik/i6UdVuZbRnHw4DCPSgDc00YKQz5sTFNJQP2qCH/UcagSKAs6cmOIM9nWnttpMyhrhs6LcMEYjDnDTrTeTZUnM=</DQ><InverseQ>pNXHwP20idqnQqJKZX4VEEEsqM+eTo+cQrNnpmSw8cgtg/Lxf9ltfa46P44rbUFrO4QTWw/tNaOIH58eOEUGg+4YbDzTpOu+HYHgfR3f7se6/O34nc9FQFVxysQ9WTUrMQQiFAWgd2dV83fD3D7Sxfhmk44wBIrnoEuCd59wwtY=</InverseQ><D>XXaUlMAskawIzFwXahB3wWrvNHY4E3rzMJ5dSxXTw2F+BRD4mKyAS3GQX3eq0rrm7rdF26gV4SghwbSY667T6c0DsqdF6MSuUoQ94Y4BSqkW0uvzaK30DEQk7OWt/vPplxzzj5V0kzXcfGc9vSXE8RdNVfhG1zCG2Bp2r/zg7gsJzS8FFk9AgZOc39663HtZf4MVJNQABdZepkkPa4mQeJLw2hdcsmtFcicIcyzzpGiSRn4yNG27Ibfg2CKZ+spr5seP+TejOTWdBv3yxPfWPUmyYQ8Av0Xu8awWocNDEOVZa2oXHbM9XffdkSueUkdry9xbXikW3ucpMiZ00DzPWQ==</D></RSAKeyValue>";

            var rsa = System.Security.Cryptography.RSA.Create();
            rsa.FromXmlString(privateKeyXml);

            var key = new Microsoft.IdentityModel.Tokens.RsaSecurityKey(rsa);
            var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.RsaSha256);

            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: new[] { new System.Security.Claims.Claim("name", "AutoUser") },
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            var tokenString = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }
    }
}