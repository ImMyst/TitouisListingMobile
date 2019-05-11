using System;

using TitouisListing.Models;
using Xamarin.Forms;

namespace TitouisListing.ViewModels
{
    public class ProductDetailPageViewModel : BaseViewModel
    {
        public Product Item { get; set; }
        public ProductDetailPageViewModel(INavigation Navigation, Product item) : base(Navigation)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
