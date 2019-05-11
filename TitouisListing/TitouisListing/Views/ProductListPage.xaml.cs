﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TitouisListing.Models;
using TitouisListing.Views;
using TitouisListing.ViewModels;

namespace TitouisListing.Views
{
    public partial class ProductListPage : ContentPage
    {
        ProductListPageViewModel viewmodel;
        public ProductListPage()
        {
            InitializeComponent();

            BindingContext = viewmodel = new ProductListPageViewModel(Navigation);
        }

        private async void ItemsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                Product selected = ((Product)e.Item);
                await Navigation.PushAsync(new ProductDetailPage(selected));
            }
        }
    }
}