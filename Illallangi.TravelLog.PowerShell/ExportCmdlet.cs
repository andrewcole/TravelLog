using System.Management.Automation;

namespace Illallangi.TravelLog
{
    public abstract class ExportCmdlet<T> : NinjectCmdlet<GeoJsonModule>
    {
        [Parameter]
        public SwitchParameter Compress { get; set; }

        protected override void EndProcessing()
        {
            WriteObject(this.Get<IExportClient<T>>().Export(Compress.ToBool()), true);
        }
    }
}