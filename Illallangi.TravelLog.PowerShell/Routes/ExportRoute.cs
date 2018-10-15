using System.Management.Automation;

namespace Illallangi.TravelLog.Routes
{
    [Cmdlet(VerbsData.Export, @"Route")]
    public sealed class ExportRoute : ExportCmdlet<IRoute>
    {
    }
}
