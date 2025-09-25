using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;


public class ApiSettings
{
  public string BaseUrl { get; set; }
}

public class FetchService
{
  private readonly HttpClient _httpClient;

  public FetchService(ApiSettings settings)
  {
    _httpClient = new HttpClient { BaseAddress = new Uri(settings.BaseUrl) };
    // _httpClient = new HttpClient();
    // baseUri = new Uri(settings.BaseUrl);
  }

  public void SetAuthorizationHeader(string token)
  {
    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
  }

  public async Task<T> GetAsync<T>(string endpoint)
  {
    var response = await _httpClient.GetAsync(endpoint);
    response.EnsureSuccessStatusCode();
    var result = await response.Content.ReadFromJsonAsync<T>();
    if (result == null)
    {
      throw new InvalidOperationException("Response content is null");
    }
    return result;
  }

  public async Task<T> PostAsync<T>(string endpoint, object data)
  {
    var response = await _httpClient.PostAsJsonAsync(endpoint, data);
    response.EnsureSuccessStatusCode();
    var result = await response.Content.ReadFromJsonAsync<T>();
    if (result == null)
    {
      throw new InvalidOperationException("Response content is null");
    }
    return result;
  }

  public async Task<T> PutAsync<T>(string endpoint, object data)
  {
    var response = await _httpClient.PutAsJsonAsync(endpoint, data);
    response.EnsureSuccessStatusCode();
    var result = await response.Content.ReadFromJsonAsync<T>();
    if (result == null)
    {
      throw new InvalidOperationException("Response content is null");
    }
    return result;
  }

  public async Task<T> DeleteAsync<T>(string endpoint)
  {
    var response = await _httpClient.DeleteAsync(endpoint);
    response.EnsureSuccessStatusCode();
    var result = await response.Content.ReadFromJsonAsync<T>();
    if (result == null)
    {
      throw new InvalidOperationException("Response content is null");
    }
    return result;
  }

  public async Task<JsonNode> GetDynamicAsync(string endpoint)
  {
    var response = await _httpClient.GetAsync(endpoint);
    response.EnsureSuccessStatusCode();
    JsonNode result = await response.Content.ReadFromJsonAsync<JsonNode>() ?? throw new InvalidOperationException("Response is null");
    return result;
  }
}