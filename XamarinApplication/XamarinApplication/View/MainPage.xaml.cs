using Xamarin.Forms;
using XamarinApplication.ViewModels;

namespace XamarinApplication.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()  
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }
    }
}