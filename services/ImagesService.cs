
using System.Diagnostics;
using blazspire.models;

public class ImagesService(FetchService api, AppState appState)
{
  private readonly FetchService api = api;
  private readonly AppState appState = appState;

  async public Task GetInspiringImage(string collection = "noon")
  {
    try
    {
      var resImage = await api.GetAsync<InspiringImage>("api/images");
      appState.Image = resImage;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      Console.WriteLine(e.StackTrace);
    }
  }
}