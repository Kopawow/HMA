using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMA.Models;
using HMA.Repositories;
using HMA.Repositories.Interfaces;
using HMA.Services;
using HMA.Services.Interfaves;

namespace HMA
{
  public partial class HMA : Form
  {
    private List<ComingHomeModel> _list = new List<ComingHomeModel>();
    private readonly IWeatherService _weatherService = new WeatherService();
    private readonly IDataRepository _dataRepository= new ExcelRepository();
    public HMA()
    {
      InitializeComponent();
      PrepareDataTable();
      Closed+= (x,e) =>
      {
        _dataRepository.SaveData(_list);
      };
    }

    private void PrepareDataTable()
    {
      try
      {
        _list = _dataRepository.GetData();
      }
      catch(Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }

    private void SetText(string text)
    {
      if (this.InvokeRequired)
      {
        Invoke(new MethodInvoker(delegate () {
          SetText(text);
        }));
      }
      else
      {
        this.textBox1.Text = text;
      }
    }

    private void bGetWeather_Click(object sender, EventArgs e)
    {
      var task = _weatherService.GetTodaysTemperature();
      task.ContinueWith(x =>
      {
        SetText(task.Result.ToString(CultureInfo.InvariantCulture));
      }
      );
    }
  
    private void bImHome_Click(object sender, EventArgs e)
    {
      var currentDateTime = DateTime.Now;
      var model = new ComingHomeModel()
      {
        Date = currentDateTime.Date,
        Hour = currentDateTime.Hour.ToString(),
        Minutes = currentDateTime.Minute.ToString()
      };

      _list.Add(model);
    }
  }
}
