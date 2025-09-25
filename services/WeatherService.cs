using System.Text.Json.Nodes;
using blazspire.models;

public class WeatherService(FetchService api, AppState appState)
{

  private readonly FetchService api = api;
  private readonly AppState appState = appState;

  public async Task GetWeather()
  {
    try
    {
      JsonNode json = await api.GetDynamicAsync("api/weather");
      appState.Weather = new Weather(json);
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      Console.WriteLine(e.StackTrace);
    }
  }
}