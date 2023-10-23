using Ecommerce.SharedKernel.Resources;
using Microsoft.Extensions.Localization;

namespace Ecommerce.SharedKernel.Interfaces
{
    public interface ICulture
    {
        public IStringLocalizer<SharedResource> SharedLocalizer { get;}
        public IStringLocalizer<PagesResource> PagesLocalizer { get;}
    }
}
