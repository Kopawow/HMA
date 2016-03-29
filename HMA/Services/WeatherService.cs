using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HMA.Services.Interfaves;

namespace HMA.Services
{
  public class WeatherService:IWeatherService
  {
    public async Task<double> GetTodaysTemperature()
    {
      string weburl = "http://api.openweathermap.org/data/2.5/forecast/city?id=3081368&APPID={197369b7e92d99c4718b5821424c7840} ";

      try
      {
        WebClient webCLient = new WebClient();
        var result = await webCLient.DownloadStringTaskAsync(new Uri(weburl));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(result);
        string szTemp = doc.DocumentElement.SelectSingleNode("temperature").Attributes["value"].Value;
        double temp = double.Parse(szTemp) - 273.16;
        return temp;
      }
      catch (Exception e)
      {
        MessageBox.Show("błąd przy pobieraniu pogody" + " "+ e.Message);
        return 0;
      }
    }
  }
}