using Newtonsoft.Json;

namespace Illallangi.TravelLog
{
    public static class ObjectExtensionMethods
    {
        public static string AsJson(this object o, bool compress=true)
        {
            return JsonConvert.SerializeObject(o, compress ? Formatting.None : Formatting.Indented);
        }
    }
}