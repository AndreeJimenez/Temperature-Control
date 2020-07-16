using SQLite;
using System;

namespace TemperatureControlApp.Models
{
    [Table("Visitor")]
    public class VisitorModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string ImageBase64 { get; set; }
    }
}
