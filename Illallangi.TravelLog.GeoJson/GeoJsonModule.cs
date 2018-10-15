using Ninject.Modules;

using Illallangi.TravelLog.Airports;
using Illallangi.TravelLog.GreatCircles;
using Illallangi.TravelLog.Routes;

namespace Illallangi.TravelLog
{
    public class GeoJsonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICreateClient<IAirport>>().To<AirportGeoJsonClient>().InSingletonScope();
            Bind<IRetrieveClient<IAirport>>().To<AirportGeoJsonClient>().InSingletonScope();
            Bind<IExportClient<IAirport>>().To<AirportGeoJsonClient>().InSingletonScope();

            Bind<ICreateClient<IRoute>>().To<RouteGeoJsonClient>().InSingletonScope();
            Bind<IRetrieveClient<IRoute>>().To<RouteGeoJsonClient>().InSingletonScope();
            Bind<IExportClient<IRoute>>().To<RouteGeoJsonClient>().InSingletonScope();

            Bind<IRetrieveClient<IGreatCircle>>().To<GreatCircleGeoJsonClient>().InSingletonScope();
            Bind<IExportClient<IGreatCircle>>().To<GreatCircleGeoJsonClient>().InSingletonScope();
        }
    }
}