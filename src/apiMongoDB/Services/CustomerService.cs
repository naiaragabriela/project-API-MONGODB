using apiMongoDB.Config;
using apiMongoDB.Models;
using MongoDB.Driver;

namespace apiMongoDB.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService (IProjSettings settings)
        {
            var customer = new MongoClient(settings.ConnectionString);
            var database = customer.GetDatabase(settings.Database);
            _customer = database.GetCollection<Customer>(settings.CustomerCollection);
        }


         public List<Customer> Get() => _customer.Find(cust => true).ToList();

        public Customer Get(string id) => _customer.Find(c => c.Id == id).FirstOrDefault();

        public Customer Create (Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;

        }

        public void Update(string id, Customer customer) => _customer.ReplaceOne(cust => cust.Id == id, customer);

        public void Delete(string id) => _customer.DeleteOne(cust => cust.Id == id);
    }
}
