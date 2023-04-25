using apiMongoDB.Config;
using apiMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace apiMongoDB.Services
{
    public class CityService
    {
        private readonly IMongoCollection<City> _city;

        public CityService(IProjSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);
            _city = database.GetCollection<City>(settings.CityCollection);
        }

        public List<City> GET() => _city.Find(c => true).ToList();
        public City Get(string Id) => _city.Find(c => c.Id == Id).FirstOrDefault();

        public City Create(City city)
        {
            _city.InsertOne(city);
            return city;
        }

        public void Update(string id, City city) => _city.ReplaceOne(c => c.Id == id, city);

        public void Delete(string id) => _city.DeleteOne(c =>c.Id == id);

        public ActionResult<List<City>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
