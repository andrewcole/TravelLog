using System;
using System.Collections.Generic;

namespace Illallangi.TravelLog.GreatCircles
{
    public class GreatCircle : IGreatCircle
    {
        private readonly Tuple<double, double> _origin;
        private readonly Tuple<double, double> _destination;
        private const double SegmentCount = 1;

        public GreatCircle(Tuple<double, double> origin, Tuple<double, double> destination)
        {
            _origin = origin;
            _destination = destination;
        }

        private List<Tuple<double, double>> _points;
        public List<Tuple<double, double>> Points => _points ?? (_points = GetPoints());

        private List<Tuple<double, double>> GetPoints()
        {
            var originLongitudeRadian = _origin.Item2 * (Math.PI / 180);
            var originLatitudeRadian = _origin.Item1 * (Math.PI / 180);
            var destinationLongitudeRadian = _destination.Item2 * (Math.PI / 180);
            var destinationLatitudeRadian = _destination.Item1 * (Math.PI / 180);
            
            var results = new List<Tuple<double, double>>();

            var distance =
                Math.Asin(
                    Math.Sqrt(
                        Math.Pow(Math.Sin((originLatitudeRadian - destinationLatitudeRadian) / 2), 2)
                        + Math.Cos(originLatitudeRadian)
                        * Math.Pow(
                            Math.Sin((originLongitudeRadian - destinationLongitudeRadian) / 2),
                            2)));

            for (double f = 0; f <= 1; f += (double)1 / SegmentCount)
            {
                var a = Math.Sin((1 - f) * distance) / Math.Sin(distance);
                var b = Math.Sin(f * distance) / Math.Sin(distance);

                // Calculate 3D Cartesian coordinates of the point
                var x = a * Math.Cos(originLatitudeRadian) * Math.Cos(originLongitudeRadian) + b * Math.Cos(destinationLatitudeRadian) * Math.Cos(destinationLongitudeRadian);
                var y = a * Math.Cos(originLatitudeRadian) * Math.Sin(originLongitudeRadian) + b * Math.Cos(destinationLatitudeRadian) * Math.Sin(destinationLongitudeRadian);
                var z = a * Math.Sin(originLatitudeRadian) + b * Math.Sin(destinationLatitudeRadian);

                var latRadian = Math.Atan2(z, Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
                var lonRadian = Math.Atan2(y, x);

                var lat = latRadian / (Math.PI / 180);
                var lon = lonRadian / (Math.PI / 180);

                results.Add(new Tuple<double, double>(lat, lon));
            }

            return results;
        }
    }
}