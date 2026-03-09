namespace PokemonBlog.Tests;

using Microsoft.EntityFrameworkCore;
using Xunit;
using PokemonBlog.Data;
using PokemonBlog.Dto;
using PokemonBlog.Models;
using PokemonBlog.Services;

public class UserServiceTests
{
    [Fact]
    public async Task UpdateUserPassword_UpdatesStoredPassword()
    {
        var options = new DbContextOptionsBuilder<PokemonContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        // Given: in-memory database with a user whose password is "oldPassword"
        await using (var context = new PokemonContext(options))
        {
            context.Database.EnsureCreated();
            var passwordService = new PasswordService();
            var hashedOld = passwordService.Hash("oldPassword");
            context.Users.Add(new User
            {
                Name = "Test",
                UserName = "testuser",
                Email = "test@example.com",
                Password = hashedOld,
                DateOfBirth = "1990-01-01",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            await context.SaveChangesAsync();
        }

        // When: UpdateUserPassword is called with "newPassword"
        await using (var context = new PokemonContext(options))
        {
            var passwordService = new PasswordService();
            var userService = new UserService(context, passwordService);

            await userService.UpdateUserPassword(new UpdatePassword
            {
                Email = "test@example.com",
                NewPassword = "newPassword"
            });
        }

        // Then: the stored password verifies against "newPassword"
        await using (var context = new PokemonContext(options))
        {
            var user = await context.Users.FirstAsync(u => u.Email == "test@example.com");
            var passwordService = new PasswordService();
            Assert.True(passwordService.Verify("newPassword", user.Password));
        }
    }
}
