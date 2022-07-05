namespace WebApp.Models
{
    public class Product:IEntity<Product>
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        Guid guid = Guid.NewGuid();

        public override string ToString()
        {
            return guid.ToString();
        }


        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
