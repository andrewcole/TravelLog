using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;

namespace Illallangi.TravelLog.Routes
{
    public static class RouteFeatureExtensionMethods
    {
        public static bool IsRoute(this Feature f)
        {
            return f.Properties.ContainsKey(@"featurecla") &&
                   f.Properties[@"featurecla"].Equals(@"route");
        }

        public static IRoute AsRoute(this Feature f)
        {
            return new Route
            {
                Origin = f.Properties[@"origin"].ToString(),
                Destination = f.Properties[@"destination"].ToString()
            };
        }
    }
}
