using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RiseX.Business.Abstract;
using RiseX.Entities.Concrete;
using RiseX.Shared.Results;
using RiseX.Shared.Utilities.Services;
using RiseX.WebUI.Controllers;

namespace RiseX.Test;

public class AuthTest
{
    private readonly IAuthService _authService;
    public AuthTest()
    {
        ConfigureServices.Services();
        _authService = ServiceTool.ServiceProvider.GetRequiredService<IAuthService>();
    }

    [Fact]
    public async Task LoginTest()
    {
        var result = await _authService.LoginAsync(new Entities.Dto.UserForLoginDto() { Email = "orhanaykac@gmail.com", Password = "a.1" });

        Assert.IsType<BaseDataResponse<User>>(result);

        Assert.True(result.Success);
    }
    [Fact]
    public async Task RegisterTest()
    {
        var result = await _authService.RegisterAsync(new Entities.Dto.UserForRegisterDto()
        {
            FirstName = "Orhan",
            LastName = "Ayka�",
            ConfirmPassword = "a.1",
            Email = $"emailaddress{Random.Shared.Next(1,999)}@gmail.com",
            Password = "a.1"
        });
        Assert.IsType<BaseDataResponse<User>>(result);

        Assert.True(result.Success);
    }
}