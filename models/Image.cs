namespace blazspire.models;

public class InspiringImage
{
  public string? Collection { get; set; }
  public string? Slug { get; set; }
  public int Height { get; set; }
  public int Width { get; set; }
  public string? Attribution { get; set; }
  public string? OriginalLink { get; set; }
  public ImageUrlsObj? ImgUrls { get; set; }
  public string? Color { get; set; }
}

public class ImageUrlsObj
{
  public string Regular { get; set; }
  public string Full { get; set; }
  public string Small { get; set; }
}