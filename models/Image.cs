namespace blazspire.models;

public class InspiringImage
{
  public string Collection { get; set; }
  public string Slug { get; set; }
  public int Height { get; set; }
  public int Width { get; set; }
  public string Attributtion { get; set; }
  public string OriginalLink { get; set; }
  public Dictionary<string, string> ImgUrls { get; set; }
  public string Color { get; set; }
}