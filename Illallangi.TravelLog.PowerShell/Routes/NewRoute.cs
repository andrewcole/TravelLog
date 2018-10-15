using System;
using System.Management.Automation;

namespace Illallangi.TravelLog.Routes
{
    [Cmdlet(VerbsCommon.New, @"Route")]
    public sealed class NewRoute : NinjectCmdlet<GeoJsonModule>, IRoute
    {
        protected override void ProcessRecord()
        {
            WriteObject(this.Get<ICreateClient<IRoute>>().Create(this), true);
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateLength(3, 3), ValidateNotNullOrEmpty]
        public string Origin { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateLength(3, 3), ValidateNotNullOrEmpty]
        public string Destination { get; set; }
    }
}