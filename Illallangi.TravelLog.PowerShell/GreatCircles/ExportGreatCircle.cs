using System.Management.Automation;

namespace Illallangi.TravelLog.GreatCircles
{
    [Cmdlet(VerbsData.Export, @"GreatCircle")]
    public sealed class ExportGreatCircle : ExportCmdlet<IGreatCircle>
    {
    }
}
