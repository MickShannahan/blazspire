

using blazspire.models;
using CommunityToolkit.Mvvm.ComponentModel;

public class AppState : ObservableObject
{
  private InspiringImage image;
  public InspiringImage Image
  {
    get => image;
    set => SetProperty(ref image, value);
  }
}