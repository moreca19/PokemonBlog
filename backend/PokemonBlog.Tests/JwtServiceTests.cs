namespace PokemonBlog.Tests;

using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Xunit;
using PokemonBlog.Models;
using PokemonBlog.Services;

public class JwtServiceTests
{
    [Fact]
    public void GenerateToken_ReturnsNonEmptyToken()
    {
        // Given: JWT config and a user
        var configData = new Dictionary<string, string?>
        {
            ["Jwt:Key"] = "TestKeyLongEnoughForHmacSha256Signature!",
            ["Jwt:Issuer"] = "TestIssuer",
            ["Jwt:Audience"] = "TestAudience",
            ["Jwt:DurationInMinutes"] = "60"
        };
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configData)
            .Build();
        var jwtService = new JwtService(configuration);
        var user = new User
        {
            Id = 1,
            Email = "test@example.com",
            UserName = "testuser",
            Name = "Test",
            Password = "ignored",
            DateOfBirth = "1990-01-01",
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        // When: GenerateToken is called
        var token = jwtService.GenerateToken(user);

        // Then: the token is non-empty
        Assert.NotNull(token);
        Assert.NotEmpty(token);
    }

    [Fact]
    public void GenerateToken_EncodesUserClaimsInToken()
    {
        // Given: JWT config and a user
        var configData = new Dictionary<string, string?>
        {
            ["Jwt:Key"] = "TestKeyLongEnoughForHmacSha256Signature!",
            ["Jwt:Issuer"] = "TestIssuer",
            ["Jwt:Audience"] = "TestAudience",
            ["Jwt:DurationInMinutes"] = "60"
        };
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configData)
            .Build();
        var jwtService = new JwtService(configuration);
        var user = new User
        {
            Id = 42,
            Email = "claims@example.com",
            UserName = "claimuser",
            Name = "Claims",
            Password = "ignored",
            DateOfBirth = "1990-01-01",
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        // When: GenerateToken is called
        var token = jwtService.GenerateToken(user);

        // Then: the decoded token contains the user id, email, and username
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        Assert.Equal("42", jwtToken.Claims.First(c => c.Type == "sub").Value);
        Assert.Equal("claims@example.com", jwtToken.Claims.First(c => c.Type == "email").Value);
        Assert.Equal("claimuser", jwtToken.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value);
    }
}
