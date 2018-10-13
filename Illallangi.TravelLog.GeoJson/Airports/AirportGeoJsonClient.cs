using System.Collections.Generic;
using System.Data;
using System.Linq;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;

namespace Illallangi.TravelLog.Airports
{
    public sealed class AirportGeoJsonClient : 
        GeoJsonClientBase, 
        ICreateClient<IAirport>, 
        IRetrieveClient<IAirport>
    {
        public IAirport Create(IAirport airport)
        {
            if (Retrieve().Count(a => a.Iata.Equals(airport.Iata)) > 0)
            {
                throw new DuplicateNameException($@"IATA {airport.Iata} Already Exists");
            }

            var properties = new Dictionary<string, object>
                {
                    {"icao", airport.Icao},
                    {"iata", airport.Iata},
                    {"name", airport.Name},
                    {"featurecla", @"airport"},
                    {"city", airport.City},
                    {"state", airport.State},
                    {"country", airport.Country},
                    {"tz", airport.Timezone},
                };

            FeatureCollection.Features.Add(new Feature(
                new Point(new Position(airport.Latitude, airport.Longitude, airport.Elevation / 3.2808399)),
                properties));

            SaveFeatureCollection(FeatureCollection);

            return Retrieve().SingleOrDefault(a => a.Iata.Equals(airport.Iata));
        }

        public IQueryable<IAirport> Retrieve()
        {
            return FeatureCollection.Features.Where(f => f.IsAirport())
                .Select(f => f.AsAirport())
                .AsQueryable();
        }
    }
}
