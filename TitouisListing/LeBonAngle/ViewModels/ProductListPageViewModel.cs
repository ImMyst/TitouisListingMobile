using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TitouisListing.Models;
using TitouisListing.Views;
using TitouisListing.Ressources;
using TitouisListing.Utils;
using TitouisListing.Services;
using System.Threading;

namespace TitouisListing.ViewModels
{
    public class ProductListPageViewModel : BaseViewModel
    {
        public ProductListPageViewModel(INavigation Navigation) : base(Navigation)
        {
            Title = MyAppRessources.Title_AnnouncesPage;
            Items = new ObservableCollection<Product>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command(async () => await ExecuteAddItemCommand());
            //Au démarrage, on charge les items
            LoadItemsCommand.Execute(null);
        }
        public ObservableCollection<Product> Items { get; set; }

        public Command LoadItemsCommand { get; set; }
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await ProductDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Command AddItemCommand { get; set; }
        private async Task ExecuteAddItemCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await NavigationService.PushAsync(new CreateAnnouncePage(), true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}