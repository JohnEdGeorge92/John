using Newtonsoft.Json.Linq;

namespace Ecommerce.SharedKernel.Extention
{
    public static class JObjectExtention
    {
        public static TReturnType GetValueType<TReturnType>(this JObject result, string jTokenKey) where TReturnType : class
        {
            if (result.GetValue(jTokenKey) is not null)
                return result.GetValue(jTokenKey).ToObject<TReturnType>();
            else
                return null;
        }

        public static bool GetValueBoolean(this JObject result, string jTokenKey)
        {
            if (result.GetValue(jTokenKey) is not null)
                return result.GetValue(jTokenKey).ToObject<bool>();
            else
                return false;
        }
    }
}
