using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using App.Models;
using Newtonsoft.Json;
using XamarinApp.Models;

namespace XamarinApplication.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    private const string url = "http//:10.0.2.2:49394/api/Dota2Db";  
    private HttpClient _Client = new HttpClient();
    public ObservableCollection<Hero> Heroes { get; set; } = new ();
    
    public MainPageViewModel()
    {
        _Client = new HttpClient(
            new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    //bypass
                    return true;
                },
            }
            , false
        );
        this.InitializeData();
    }

    private async void InitializeData()
    {
        var content = await _Client.GetStringAsync(url);
        var heroes = JsonConvert.DeserializeObject<List<Hero>>(content);

        foreach (var hero in heroes)
        {
            Heroes.Add(hero);
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected virtual void OnPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}