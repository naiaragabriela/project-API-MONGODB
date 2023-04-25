namespace apiMongoDB.Config
{
    public class ProjSettings : IProjSettings
    {
        public string CityCollection { get; set; }
        public string AddressController { get; set; }
        public string CustomerCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
