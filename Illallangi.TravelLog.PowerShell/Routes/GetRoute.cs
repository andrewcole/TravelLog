using System.Management.Automation;

namespace Illallangi.TravelLog.Routes
{
    [Cmdlet(VerbsCommon.Get, @"Route")]
    public sealed class GetRoute : GetCmdlet<IRoute>
    {
    }
}
