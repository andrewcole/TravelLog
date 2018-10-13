namespace Illallangi.TravelLog
{
    public interface ICreateClient<T>
    {
        T Create(T t);
    }
}