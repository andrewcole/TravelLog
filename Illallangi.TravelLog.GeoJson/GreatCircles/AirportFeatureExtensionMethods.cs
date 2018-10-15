using System;
using System.Collections.Generic;
using System.Linq;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;

namespace Illallangi.TravelLog.GreatCircles
{
    public static class GreatCircleFeatureExtensionMethods
    {
        public static FeatureCollection AsFeatureCollection(this IEnumerable<IGreatCircle> greatCircles)
        {
            return new FeatureCollection(
                greatCircles.Select(greatCircle => new Feature(
                    new MultiLineString(
                        greatCircle.Points.Skip(1).Zip(greatCircle.Points, (current, previous) => 
                            new LineString(new [] { new [] { previous.Item2, previous.Item1 }, new []{current.Item2, current.Item1} }))))).ToList());
        }
    }
}
