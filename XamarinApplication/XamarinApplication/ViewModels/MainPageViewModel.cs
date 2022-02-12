using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using XamarinApp.Models;

namespace XamarinApplication.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    private const string url = "https://jsonplaceholder.typicode.com/users";  
    private HttpClient _Client = new HttpClient();
    public ObservableCollection<User> User { get; set; } = new ();
    
    public MainPageViewModel()
    {
        this.InitializeData();
    }

    private async void InitializeData()
    {
        var content = await _Client.GetStringAsync(url);
        var users = JsonConvert.DeserializeObject<List<User>>(content);

        foreach (var user in users)
        {
            User.Add(user);
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected virtual void OnPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}