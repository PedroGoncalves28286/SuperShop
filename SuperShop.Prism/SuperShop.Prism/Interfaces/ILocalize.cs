using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Prism.Interfaces
{
    internal interface ILocalize
    {
        CultureInfo GetCurrentCultureINfo();

        void SetLocale(CultureInfo ci);
    }
}
