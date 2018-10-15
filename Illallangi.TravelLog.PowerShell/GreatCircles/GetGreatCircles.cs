using System.Management.Automation;

namespace Illallangi.TravelLog.GreatCircles
{
    [Cmdlet(VerbsCommon.Get, @"GreatCircle")]
    public sealed class GetGreatCircles : GetCmdlet<IGreatCircle>
    {
    }
}
