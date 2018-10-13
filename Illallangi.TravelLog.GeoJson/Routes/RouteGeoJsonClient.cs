using System.Collections.Generic;
using System.Data;
using System.Linq;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Illallangi.TravelLog.Airports;

namespace Illallangi.TravelLog.Routes
{
    public sealed class RouteGeoJsonClient : 
        GeoJsonClientBase, 
        ICreateClient<IRoute>,
        IRetrieveClient<IRoute>
    {
        private IRetrieveClient<IAirport> _airportRetrieveClient;

        public RouteGeoJsonClient(IRetrieveClient<IAirport> airportRetrieveClient)
        {
            _airportRetrieveClient = airportRetrieveClient;
        }

        public IRoute Create(IRoute airport)
        {
            if (Retrieve().Count(a => a.Origin.Equals(airport.Origin) && a.Destination.Equals(airport.Destination)) > 0)
            {
                throw new DuplicateNameException($@"Route {airport.Origin} to {airport.Destination} Already Exists");
            }

            var origin = _airportRetrieveClient.Retrieve().SingleOrDefault(a => a.Iata.Equals(airport.Origin));
            if (origin == null)
            {
                throw new DuplicateNameException($@"Airport {airport.Origin} Does Not Exists");
            }

            var destination = _airportRetrieveClient.Retrieve().SingleOrDefault(a => a.Iata.Equals(airport.Destination));
            if (destination == null)
            {
                throw new DuplicateNameException($@"Airport {airport.Destination} Does Not Exists");
            }

            var properties = new Dictionary<string, object>
            {
                {"featurecla", @"route"},
                {"origin", airport.Origin},
                {"destination", airport.Destination},
            };

            FeatureCollection.Features.Add(new Feature(
                new LineString(new[]
                {
                    new Position(origin.Latitude, origin.Longitude, origin.Elevation / 3.2808399),
                    new Position(destination.Latitude, destination.Longitude, destination.Elevation / 3.2808399),
                }),
                properties));

            SaveFeatureCollection(FeatureCollection);

            return Retrieve().SingleOrDefault(a => a.Origin.Equals(airport.Origin) && a.Destination.Equals(airport.Destination));
        }

        public IQueryable<IRoute> Retrieve()
        {
            return FeatureCollection.Features.Where(f => f.IsRoute())
                .Select(f => f.AsRoute())
                .AsQueryable();
        }
    }
}
