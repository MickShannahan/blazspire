using System.Security.Claims;
using Auth0.OidcClient;
using Microsoft.AspNetCore.Components.Authorization;

public class Auth0Provider : AuthenticationStateProvider
{

  private ClaimsPrincipal currentUser = new ClaimsPrincipal(new ClaimsIdentity());

  private readonly Auth0Client auth0Client;

  public Auth0Provider(Auth0Client auth0Client)
  {
    this.auth0Client = auth0Client;
  }

  public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(new AuthenticationState(currentUser));

  public Task LogInAsync()
  {
    var loginTask = LogInAsyncCore();
    NotifyAuthenticationStateChanged(loginTask);

    return loginTask;

    async Task<AuthenticationState> LogInAsyncCore()
    {
      var user = await LoginWithAuth0Async();
      currentUser = user;

      return new AuthenticationState(currentUser);
    }
  }

  private async Task<ClaimsPrincipal> LoginWithAuth0Async()
  {
    var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity());
    var loginResult = await auth0Client.LoginAsync();

    if (!loginResult.IsError)
    {
      authenticatedUser = loginResult.User;
    }
    return authenticatedUser;
  }

  public async void LogOut()
  {
    await auth0Client.LogoutAsync();
    currentUser = new ClaimsPrincipal(new ClaimsIdentity());
    NotifyAuthenticationStateChanged(
        Task.FromResult(new AuthenticationState(currentUser)));
  }
}



public class AuthSettings
{
  public string Domain { get; set; }
  public string ClientId { get; set; }
  public string Scope { get; set; } = "openid profile";
  public string RedirectUri = "myapp://callback/";
  public string PostLogoutRedirectUri = "myapp://callback/";
}