﻿namespace Illallangi.TravelLog.Airports
{
    public class Airport : IAirport
    {
        public string Iata { get; set; }
        public string Icao { get; set; }
        public double Elevation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }
    }
}