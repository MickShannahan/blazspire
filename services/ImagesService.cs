
using blazspire.models;

public class ImagesService(FetchService api)
{
  private readonly FetchService api = api;

  async public Task GetInspiringImage(string collection = "noon")
  {
    try
    {
      var response = await api.GetAsync<InspiringImage>("/api/images");
      Console.WriteLine($"{response.Attributtion}");
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      Console.WriteLine(e.StackTrace);
    }
  }
}