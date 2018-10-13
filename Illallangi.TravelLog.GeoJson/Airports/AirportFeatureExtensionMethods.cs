using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;

namespace Illallangi.TravelLog.Airports
{
    public static class AirportFeatureExtensionMethods
    {
        public static bool IsAirport(this Feature f)
        {
            return f.Properties.ContainsKey(@"featurecla") &&
                   f.Properties[@"featurecla"].Equals(@"airport");
        }

        public static IAirport AsAirport(this Feature f)
        {
            return new Airport
            {
                Icao = f.Properties[@"icao"].ToString(),
                Iata = f.Properties[@"iata"].ToString(),
                Name = f.Properties[@"name"].ToString(),
                City = f.Properties[@"city"].ToString(),
                State = f.Properties[@"state"].ToString(),
                Country = f.Properties[@"country"].ToString(),
                Timezone = f.Properties[@"tz"].ToString(),
                Latitude = ((Point)f.Geometry).Coordinates.Latitude,
                Longitude = ((Point)f.Geometry).Coordinates.Longitude,
                Elevation = ((Point)f.Geometry).Coordinates.Altitude.Value
            };
        }
    }
}
