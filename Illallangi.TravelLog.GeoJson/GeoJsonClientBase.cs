using System;
using GeoJSON.Net.Feature;
using Newtonsoft.Json;

namespace Illallangi.TravelLog
{
    public abstract class GeoJsonClientBase
    {
        private FeatureCollection _featureCollection;
        protected FeatureCollection FeatureCollection => _featureCollection ?? (_featureCollection = GetFeatureCollection());

        private static FeatureCollection GetFeatureCollection()
        {
            if (!System.IO.File.Exists(GeoJsonPath))
            {
                return SaveFeatureCollection(new FeatureCollection());
            }

            return JsonConvert.DeserializeObject<FeatureCollection>(
                System.IO.File.ReadAllText(GeoJsonPath));
        }

        protected static FeatureCollection SaveFeatureCollection(FeatureCollection featureCollection)
        {
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(GeoJsonPath)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(GeoJsonPath));
            }

            System.IO.File.WriteAllText(GeoJsonPath, JsonConvert.SerializeObject(featureCollection, Formatting.Indented));

            return featureCollection;
        }

        private static readonly string GeoJsonPath =
            System.IO.Path.GetFullPath(
                Environment.ExpandEnvironmentVariables(@"%appdata%\Illallangi Enterprises\TravelLog.geojson"));
    }
}