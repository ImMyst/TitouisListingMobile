﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TitouisListing.Models;
using TitouisListing.Views;
using TitouisListing.Ressources;
using TitouisListing.Utils;
using TitouisListing.Services;

namespace TitouisListing.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel(INavigation Navigation) : base(Navigation)
        {
            Title = MyAppRessources.Title_AnnouncesPage;
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
#if DEBUG
            Login = "jerome.liger@respawnsive.com";
            Password = "BrHpd/XQ3,P%";
#endif
        }

        private string login = Settings.Login;
        public string Login
        {
            get { return login; }
            set { SetProperty(ref login, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private string errorMessage = String.Empty;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public Command LoginCommand { get; set; }
        private async Task ExecuteLoginCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                //
                if (!String.IsNullOrWhiteSpace(Login)
                    && !String.IsNullOrWhiteSpace(Password))
                {
                    Settings.Login = Login;
                    Settings.Pwd = Password;
                    Settings.TokenAPI = String.Empty;

                    TitouisListingWebServices client = new TitouisListingWebServices();
                    var result = await client.APIV2_AuthenticateUser();
                    if (result)
                    {
                        ErrorMessage = "";
                        ((TitouisApp)Application.Current).DisplayHome();
                    }
                    else
                    {
                        ErrorMessage = MyAppRessources.LoginPage_LblError_Unknown;
                    }
                }
                else
                {
                    ErrorMessage = MyAppRessources.LoginPage_LblError_Uncomplete;
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

    }
}