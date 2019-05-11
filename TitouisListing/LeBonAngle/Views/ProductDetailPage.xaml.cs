using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TitouisListing.Models;
using TitouisListing.ViewModels;

namespace TitouisListing.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        ProductDetailPageViewModel viewmodel;
        public ProductDetailPage(Product item)
        {
            InitializeComponent();
            BindingContext = viewmodel = new ProductDetailPageViewModel(Navigation, item);
        }
    }
}