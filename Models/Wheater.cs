using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetVueBlog.Models
{
    public class Wheather {
        public int ID { get; set; }

        public DateTime DateFormatted { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }

        public bool IsActive { get; set; }
    }

}