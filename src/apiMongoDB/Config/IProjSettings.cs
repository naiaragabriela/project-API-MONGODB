namespace apiMongoDB.Config
{
    public interface IProjSettings
    {
        string CityCollection { get; set; }
        string AddressCollection { get; set; }
        string CustomerCollection { get; set; }
        string ConnectionString { get; set; }
        string Database { get; set; }

    }
}
