using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TitouisListing.Interfaces
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
