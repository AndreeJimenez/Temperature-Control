using SQLite;
using System;

namespace TemperatureControlApp.Models
{
    [Table("Temperature")]
    public class TemperatureModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public double Temperature { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Comments { get; set; }
    }
}
