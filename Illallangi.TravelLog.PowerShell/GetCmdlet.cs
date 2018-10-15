namespace Illallangi.TravelLog
{
    public abstract class GetCmdlet<T> : NinjectCmdlet<GeoJsonModule>
    {
        protected override void EndProcessing()
        {
            WriteObject(this.Get<IRetrieveClient<T>>().Retrieve(), true);
        }
    }
}