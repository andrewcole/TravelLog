using System.Linq;

namespace Illallangi.TravelLog
{
    public interface IRetrieveClient<out T>
    {
        IQueryable<T> Retrieve();
    }
}
