using Ecommerce.SharedKernel.Interfaces;
using Ecommerce.SharedKernel.Resources;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Ecommerce.SharedKernel.Helpers
{
    public partial class Culture
    {
        public static readonly string[] _supportedCultures;
        public static int culture {get;set;}
        static Culture()
        {
            _supportedCultures = new [] {
                  "ar-EG"
                , "en"
            };
        }
        public static int CurrentIndex()
        {
            return getIndexOfCulture(Thread.CurrentThread.CurrentCulture.Name);
        }
        private static int getIndexOfCulture(string cultureName)
        {
            if (cultureName.StartsWith("ar"))
                return 0;

            else if (cultureName.StartsWith("en"))
                return 1;

            else
                return 0;
        }
        public static CultureInfo[] GetSupportedCulturesInfo()
        {
            var supportedCulturesInfo = new CultureInfo[_supportedCultures.Length];
            for (int i = 0; i < _supportedCultures.Length; i++)
            {
                supportedCulturesInfo[i] = new CultureInfo(_supportedCultures[i].ToString());
            }
            return supportedCulturesInfo;
        }

    }


    public partial class Culture : ICulture
    {
        public IStringLocalizer<SharedResource> SharedLocalizer { get; private set; }
        public IStringLocalizer<PagesResource> PagesLocalizer { get; private set; }

        public Culture(IStringLocalizer<SharedResource> SharedLocalizer, IStringLocalizer<PagesResource> PagesLocalizer)
        {
            this.SharedLocalizer = SharedLocalizer;
            this.PagesLocalizer = PagesLocalizer;
        }
    }
}
