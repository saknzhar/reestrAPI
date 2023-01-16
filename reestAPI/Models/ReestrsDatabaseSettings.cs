using System;
namespace reestAPI.Models
{
    public class ReestrDatabaseSettings : IReestrDatabaseSettings
    {
        public string ReestrCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IReestrDatabaseSettings
    {
        string ReestrCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

