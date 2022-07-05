namespace WebApp.Models
{
    public class Manager
    {
        public IEntity<Product> Product { get; set; }

        public Manager(IEntity<Product> product)
        {
            Product= product; 
        }
    }
}
