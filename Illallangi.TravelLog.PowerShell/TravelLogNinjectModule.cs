using Illallangi.TravelLog.Airports;
using Illallangi.TravelLog.Routes;
using Ninject.Modules;

namespace Illallangi.TravelLog
{
    public class TravelLogNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICreateClient<IAirport>>().To<AirportGeoJsonClient>().InSingletonScope();
            Bind<IRetrieveClient<IAirport>>().To<AirportGeoJsonClient>().InSingletonScope();

            Bind<ICreateClient<IRoute>>().To<RouteGeoJsonClient>().InSingletonScope();
            Bind<IRetrieveClient<IRoute>>().To<RouteGeoJsonClient>().InSingletonScope();
        }
    }
}