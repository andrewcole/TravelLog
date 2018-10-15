using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.TravelLog.Airports;
using Illallangi.TravelLog.Routes;

namespace Illallangi.TravelLog.GreatCircles
{
    public sealed class GreatCircleGeoJsonClient :
        GeoJsonClientBase,
        IRetrieveClient<IGreatCircle>,
        IExportClient<IGreatCircle>
    {
        private readonly IRetrieveClient<IAirport> _airportRetrieveClient;
        private readonly IRetrieveClient<IRoute> _routeRetrieveClient;

        public GreatCircleGeoJsonClient(IRetrieveClient<IAirport> airportRetrieveClient,IRetrieveClient<IRoute> routeRetrieveClient)
        {
            _airportRetrieveClient = airportRetrieveClient;
            _routeRetrieveClient = routeRetrieveClient;
        }

        public IQueryable<IGreatCircle> Retrieve()
        {
            return _routeRetrieveClient.Retrieve().Select(r => new GreatCircle(
                new Tuple<double, double>(
                    _airportRetrieveClient.Retrieve().SingleOrDefault(a => a.Iata.Equals(r.Origin)).Latitude,
                    _airportRetrieveClient.Retrieve().SingleOrDefault(a => a.Iata.Equals(r.Origin)).Longitude),
                new Tuple<double, double>(
                    _airportRetrieveClient.Retrieve().SingleOrDefault(a => a.Iata.Equals(r.Destination)).Latitude,
                    _airportRetrieveClient.Retrieve().SingleOrDefault(a => a.Iata.Equals(r.Destination)).Longitude)));
        }

        public string Export(bool compress=true)
        {
            return Retrieve().AsFeatureCollection().AsJson(compress);
        }
    }
}