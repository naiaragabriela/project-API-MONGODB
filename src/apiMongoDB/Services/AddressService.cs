using apiMongoDB.Config;
using apiMongoDB.Models;
using MongoDB.Driver;

namespace apiMongoDB.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;

        public AddressService(IProjSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);
            _address = database.GetCollection<Address>(settings.AddressCollection);
        }

        public List<Address> Get() => _address.Find(a => true).ToList();

        public Address Get(string id) => _address.Find(a=>a.Id== id).FirstOrDefault();

        public Address Create(Address address)
        {
            _address.InsertOne(address);
            return address;
        }

        public void Update(string id, Address address) => _address.ReplaceOne(a => a.Id == id, address);

        public void Delete(string id) => _address.DeleteOne(a => a.Id == id);
    }
}
