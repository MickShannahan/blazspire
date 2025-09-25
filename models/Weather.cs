using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

namespace blazspire.models;

public class Weather
{

  [Required] public string Description { get; set; }
  [Required] public string Icon { get; set; }
  public double Celsius { get; set; }
  public double Fahrenheit { get; set; }
  public double Kelvin { get; set; }
  public bool showImperial { get; set; } = false;


  public Weather(JsonNode json)
  {
    Description = json["weather"][0]["description"].GetValue<string>();
    Icon = json["weather"]["icon"].GetValue<string>();
    Celsius = json["main"]["temp"].GetValue<double>() - 273.15;
    Fahrenheit = (json["main"]["temp"].GetValue<double>() - 273.15) * 9 / 5 + 32;
    Kelvin = json["main"]["temp"].GetValue<double>();
  }

  // public static Weather FromJson(JsonNode json)
  // {
  //   var weather = new Weather();

  //   return weather;
  // }
}
