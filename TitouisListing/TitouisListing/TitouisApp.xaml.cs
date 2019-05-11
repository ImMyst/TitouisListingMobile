using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TitouisListing.Views;
using TitouisListing.Interfaces;
using TitouisListing.ViewModels;
using TitouisListing.Services;
using TitouisListing.Models;
using System.Threading.Tasks;
using TitouisListing.Utils;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TitouisListing
{
    public partial class TitouisApp : Application
    {

        public TitouisApp()
        {
            InitializeComponent();
            //DependencyService.Register<IDataStore<Announce>>();
            DependencyService.Register<IDataStore<Product>>();
            var currentSmartphoneLanguage = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            
            if (Settings.IsUserConnected)
            {
                DisplayHome();
            }
            else
            {
                DisplayLogin();
            }
        }

        public void DisplayLogin()
        {
            //Affectation Mainpage
            MainPage = new LoginPage();
        }

        public void DisplayHome()
        {
            //Affectation Mainpage
            MainPage = new MDPage();
        }

        
    }
}
