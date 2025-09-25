

using blazspire.models;
using CommunityToolkit.Mvvm.ComponentModel;

public class AppState(IDispatcher dispatcher) : ObservableObject
{
  private InspiringImage image;
  public InspiringImage Image
  {
    get => image;
    set
    {
      SetProperty(ref image, value);
      NotifyStateChange("Image");
    }
  }

  private Weather weather;
  public Weather Weather
  {
    get => weather;
    set
    {
      SetProperty(ref weather, value);
      NotifyStateChange("Weather");
    }
  }

  private Account account;
  public Account Account
  {
    get => account;
    set
    {
      SetProperty(ref account, value);
      NotifyStateChange("Account");
    }
  }

  public event Action? OnChange;

  private readonly IDispatcher _dispatcher = dispatcher;

  public void NotifyStateChange(string act = "-")
  {
    Console.WriteLine($"[update] {act}");
    MainThread.BeginInvokeOnMainThread(() =>
    {
      if (_dispatcher.IsDispatchRequired)
      {
        _dispatcher.Dispatch(() => OnChange?.Invoke());
      }
      else
      {
        OnChange?.Invoke();
      }
    });
  }
}