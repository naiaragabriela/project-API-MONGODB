namespace apiMongoDB.Config
{
    public interface IapiMongoDB
    {
        string CityCollection { get; set; }
        string AddressController { get; set; }
        string CustomerCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
