using Newtonsoft.Json;

namespace SaAPI.Utility.Error
{
    public static class ObjectExtension
    {
        public static string ToJsonDefault(this object input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}