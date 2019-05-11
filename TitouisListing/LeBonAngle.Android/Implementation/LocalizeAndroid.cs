using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TitouisListing.Droid.Implementation;
using TitouisListing.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalizeAndroid))]
namespace TitouisListing.Droid.Implementation
{
    public class LocalizeAndroid : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-"); // turns fr_FR into fr-FR
            var localiz = new CultureInfo(netLanguage);
            return localiz;
        }
    }
}