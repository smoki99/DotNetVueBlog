using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotNetVueBlog.Models
{
    public class WheatherContext : DbContext
    {
        public WheatherContext(DbContextOptions<WheatherContext> options) : base(options)
        {
        }

        public DbSet<Wheather> Wheather { get; set; }

        public void EnsureSeedData()
        {
            var context = this;

            // Nur wenn die Tabelle leer ist
            if (!context.Wheather.Any()) { 
                   context.Wheather.Add(
                        new Wheather() {
                            DateFormatted = Convert.ToDateTime("2018-03-01"),
                            TemperatureC = 5,
                            Summary = "Kalt"
                        });
                    context.Wheather.Add(
                        new Wheather() {
                            DateFormatted = Convert.ToDateTime("2018-03-08"),
                            TemperatureC = 10,
                            Summary = "Kühl"
                        });
                    context.Wheather.Add(
                        new Wheather() {
                            DateFormatted = Convert.ToDateTime("2018-03-15"),
                            TemperatureC = 15,
                            Summary = "Warm"
                        });
                    context.Wheather.Add(
                        new Wheather() {
                            DateFormatted = Convert.ToDateTime("2018-03-23"),
                            TemperatureC = 20,
                            Summary = "Schön"
                        });

                    context.SaveChanges();
            }
        }
    }
}