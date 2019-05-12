using TitouisListing.Models;
using TitouisListing.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TitouisListing.Services
{
    public class TitouisListingWebServices
    {
        public async Task<bool> APIV2_AuthenticateUser()
        {
            try
            {
                HttpClient clientTest = new HttpClient();
                Dictionary<string, string> keys = new Dictionary<string, string>();
                keys.Add("email", Settings.Login);
                keys.Add("password", Settings.Pwd);
                FormUrlEncodedContent content = new FormUrlEncodedContent(keys);
                var response = await clientTest.PostAsync(@"http://louis-charavner.fr:8887/api/v1/auth_user", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Authenticate>(responsedata);
                    Settings.TokenAPI = responseformatted.AuthToken;
                    Settings.UserID = responseformatted.User.Id.Oid;
                    return true;
                }
                else
                {
                    Settings.TokenAPI = String.Empty;
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Settings.TokenAPI = String.Empty;
                return false;
            }
        }

        public async Task<bool> APIV2_PostAnnounce(Product product)
        {

            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await APIV2_AuthenticateUser();
            }

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", Settings.TokenAPI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var contentstring = "{\"annonce\":" + JsonConvert.SerializeObject(product) + ",\"author\":";
                StringContent content = new StringContent(contentstring, Encoding.UTF8, "application/json");

                content.Headers.Add("token", Settings.TokenAPI);
                var response = await client.PostAsync(@"http://louis-charavner.fr:8887/api/v1/annonce/create", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Products>(responsedata);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        //API_Response_Category
        public async Task<Category[]> APIV2_GetCategories()
        {
            var resultats = new Category[0];
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await APIV2_AuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("Authorization", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"http://louis-charavner.fr:8887/api/v1/category");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Category>(responsedata);
                    return responseformatted.Categories;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //RéAuthentifie
                    if (await APIV2_AuthenticateUser())
                    {
                        //On rejoue la requête après authentification correcte
                        return await APIV2_GetCategories();
                    }
                    else
                    {
                        //Réauthentification NOK... dialog ?
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return resultats;
        }

        public async Task<bool> APIV2_PostCategory(Category category)
        {

            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await APIV2_AuthenticateUser();
            }

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", Settings.TokenAPI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var contentstring = "{\"category\":" + JsonConvert.SerializeObject(category) + "}";
                StringContent content = new StringContent(contentstring, Encoding.UTF8, "application/json");
                //content.Headers.Add("token", Settings.TokenAPI);
                var response = await client.PostAsync(@"http://louis-charavner.fr:8887/api/v1/category/create", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Products>(responsedata);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<Product[]> APIV2_GetAnnounces()
        {
            var resultats = new Product[0];
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await APIV2_AuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("Authorization", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"http://louis-charavner.fr:8887/api/v1/annonce");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Products>(responsedata);
                    return responseformatted.Products;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //RéAuthentifie
                    if (await APIV2_AuthenticateUser())
                    {
                        //On rejoue la requête après authentification correcte
                        return await APIV2_GetAnnounces();
                    }
                    else
                    {
                        //Réauthentification NOK... dialog ?
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return resultats;
        }

        public async Task<Product> APIV2_GetAnnounce(string id)
        {
            Product resultat = new Product();
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await APIV2_AuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("Authorization", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"http://louis-charavner.fr:8887/api/v1/annonce/get/" + id);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Products_Id>(responsedata);
                    return responseformatted.Products;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //RéAuthentifie
                    if (await APIV2_AuthenticateUser())
                    {
                        //On rejoue la requête après authentification correcte
                        return await APIV2_GetAnnounce(id);
                    }
                    else
                    {
                        //Réauthentification NOK... dialog ?
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return resultat;
        }

        public async Task<User> APIV2_GetMyAccount()
        {
            User resultat = new User();
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await APIV2_AuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("Authorization", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"http://louis-charavner.fr:8887/api/v1/account/" + Settings.UserID);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_User_Id>(responsedata);
                    return responseformatted.User;
                }
                else
                {
                    Console.WriteLine($"APIV2_GetMyAccount Error ==> {response}");
                }

            }
            catch (Exception ex)
            {

            }
            return resultat;
        }
    }
}
