using System.Management.Automation;

namespace Illallangi.TravelLog.Airports
{
    [Cmdlet(VerbsCommon.Get, @"Airport")]
    public sealed class GetAirport : GetCmdlet<IAirport>
    {
    }
}
