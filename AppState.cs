

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
      NotifyStateChange();
      SetProperty(ref image, value);
    }
  }

  public event Action? OnChange;

  private readonly IDispatcher _dispatcher = dispatcher;

  public void NotifyStateChange()
  {
    Console.WriteLine("[update]");
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