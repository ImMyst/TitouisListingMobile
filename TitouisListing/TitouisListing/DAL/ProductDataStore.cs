using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitouisListing.DAL;
using TitouisListing.Interfaces;
using TitouisListing.Models;
using TitouisListing.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProductDataStore))]
namespace TitouisListing.DAL
{
    public class ProductDataStore : IDataStore<Product>
    {

        public ProductDataStore()
        {

        }

        public async Task<bool> AddItemAsync(Product item)
        {
            //Need API
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Product item)
        {
            //Need API !!!

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            //Need API !!!

            return await Task.FromResult(true);
        }

        public async Task<Product> GetItemAsync(string id)
        {
            TitouisListingWebServices WSclient = new TitouisListingWebServices();
            return await WSclient.APIV2_GetAnnounce(id);
        }

        public async Task<List<Product>> GetItemsAsync(bool forceRefresh = false)
        {
            TitouisListingWebServices WSclient = new TitouisListingWebServices();
            return await WSclient.APIV2_GetAnnounces();
        }
    }
}