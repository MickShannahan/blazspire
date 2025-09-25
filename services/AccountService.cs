

using blazspire.models;

public class AccountService(FetchService api, AppState appState)
{

  public async Task GetAccount()
  {
    try
    {
      var accountRes = await api.GetAsync<Account>("account");
      appState.Account = accountRes;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      Console.WriteLine(e.StackTrace);
    }
  }
}