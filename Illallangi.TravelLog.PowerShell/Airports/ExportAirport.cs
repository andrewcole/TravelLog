using System.Management.Automation;

namespace Illallangi.TravelLog.Airports
{
    [Cmdlet(VerbsData.Export, @"Airport")]
    public sealed class ExportAirport : ExportCmdlet<IAirport>
    {
    }
}
