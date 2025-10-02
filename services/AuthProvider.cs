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
    // Auth0.OidcClient.Platforms.Windows.Activator.Default.CheckRedirectionActivation();
  }

  public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(new AuthenticationState(currentUser));

  public Task LogInAsync()
  {
    Console.WriteLine("1.LogInAsync");
    var loginTask = LogInAsyncCore();
    NotifyAuthenticationStateChanged(loginTask);

    return loginTask;

    async Task<AuthenticationState> LogInAsyncCore()
    {
      Console.WriteLine("2.LogInAsyncCore");
      var user = await LoginWithAuth0Async();
      currentUser = user;

      return new AuthenticationState(currentUser);
    }
  }

  private async Task<ClaimsPrincipal> LoginWithAuth0Async()
  {
    Console.WriteLine("3.LoginWithAuth0Async");
    // Microsoft.Windows.AppLifecycle.ActivationRegistrationManager.RegisterForProtocolActivation("myapp", "my app title", null);
    // var loginResult = await WebAuthenticator.AuthenticateAsync("https://mickshanny.us.auth0.com/", "myapp://callback/");
    var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity());
    var loginResult = await auth0Client.LoginAsync();
    Console.WriteLine(loginResult);

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