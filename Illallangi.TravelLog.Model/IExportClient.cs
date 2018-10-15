using System.Linq;

namespace Illallangi.TravelLog
{
    public interface IExportClient<out T>
    {
        string Export(bool compress = true);
    }
}
