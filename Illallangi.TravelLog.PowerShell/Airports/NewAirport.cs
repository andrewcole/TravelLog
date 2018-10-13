using System;
using System.Management.Automation;

namespace Illallangi.TravelLog.Airports
{
    [Cmdlet(VerbsCommon.New, @"Airport")]
    public sealed class NewAirport : NinjectCmdlet<TravelLogNinjectModule>, IAirport
    {
        protected override void ProcessRecord()
        {
            WriteObject(this.Get<ICreateClient<IAirport>>().Create(this), true);
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateLength(3, 3), ValidateNotNullOrEmpty]
        public string Iata { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateLength(4, 4), ValidateNotNullOrEmpty]
        public string Icao { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public double Elevation { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public double Latitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public double Longitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string City { get; set; }
        
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string State { get; set; }
        
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Country { get; set; }
        
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Timezone { get; set; }
    }
}