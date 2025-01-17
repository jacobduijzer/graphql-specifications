using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace Bookstore.Api;

public static class AuthenticationAndAuthorizationExtensions
{
    public static IServiceCollection ConfigureAuthentication(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IdentityService>()
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IdentityService.PrivateKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
       
        return serviceCollection;
    }  
    
    public static IServiceCollection ConfigureAuthorization(this IServiceCollection serviceCollection)
    {
        var customerPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireRole(IdentityService.CustomerRole)
            .Build();
        
        var bookstoreOwnerPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireRole(IdentityService.BookstoreOwnerRole)
            .Build();
        
        serviceCollection
            .AddAuthorizationBuilder()
            .AddPolicy(IdentityService.CustomerRole, customerPolicy)
            .AddPolicy(IdentityService.BookstoreOwnerRole, bookstoreOwnerPolicy);
        
        return serviceCollection;
    }
}