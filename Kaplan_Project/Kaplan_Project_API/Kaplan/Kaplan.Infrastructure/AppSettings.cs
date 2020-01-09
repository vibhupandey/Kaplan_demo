namespace Order_Kitting.Infrastructure
{
    public interface IAppSettings
    {
        string ConnectionString { get; set; } 
    }
    public class AppSettings : IAppSettings
    {
        public AppSettings(string connectionString )
        {
            ConnectionString = connectionString; 
        }

        public string ConnectionString { get; set; } 
    } 
}
