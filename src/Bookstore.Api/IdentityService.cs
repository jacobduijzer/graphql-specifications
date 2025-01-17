using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Bookstore.Api;

public class IdentityService
{
    public static readonly string PrivateKey = "bAafd@A7d9#@F4*V!LHZs#ebKQrkE6pad2c3dXy@";
    public static readonly string CustomerRole = "Customer";
    public static readonly string BookstoreOwnerRole = "BookstoreOwner";

    public string Login(string email, string password)
    {
        var handler = new JwtSecurityTokenHandler();

        var privateKey = Encoding.UTF8.GetBytes(PrivateKey);

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(privateKey),
            SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(1),
            Subject = GenerateClaims(email)
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    private static ClaimsIdentity GenerateClaims(string email)
    {
        var ci = new ClaimsIdentity();

        ci.AddClaim(new Claim(ClaimTypes.Email, email));
        ci.AddClaim(email.Contains("owner")
            ? new Claim(ClaimTypes.Role, BookstoreOwnerRole)
            : new Claim(ClaimTypes.Role, CustomerRole));

        return ci;
    }
}