namespace WebApp.Models
{
    public interface IEntity<T> where T : class
    {
        List<T> GetAll();
    }
}
