namespace Fly_Api_MongoDB.Configurations
{
    public class FlySettings : IFlySettings
    {
        public string Server { get; set; }
        public string DataBase { get; set; }
        public string Collection { get; set; }

    }

    public interface IFlySettings
    {
        string Server { get; set; }
        string DataBase { get; set; }
        string Collection { get; set; }

    }
}