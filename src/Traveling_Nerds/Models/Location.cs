using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ForecastIO;
using ForecastIO.Extensions;


namespace Traveling_Nerds.Models
{
    [Table("Locations")]
    public class Location
    {
        public Location()
        {
            this.Postings = new HashSet<Posting>();
        }
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Posting> Postings { get; set; }

        public static List<Dictionary<string, string>> GetWeatherForecast(float lat, float lon)
        {
            var request = new ForecastIORequest(EnvironmentVariables.ApiKey, lat, lon, Unit.us);
            var response = request.Get();
            dynamic daily = response.daily.data;
            var list = new List<Dictionary<string, string>>();
            for (int i = 0; i < 7; i++)
            {
                var loc = new Dictionary<string, string>();
                loc.Add("date", DateTime.Now.AddDays(i).ToString("dddd, MMMM dd, yyyy"));
                loc.Add("maxTemp", response.daily.data[i].temperatureMax.ToString());
                loc.Add("minTemp", response.daily.data[i].temperatureMin.ToString());
                loc.Add("summary", response.daily.data[i].summary);
                list.Add(loc);
            }
            return list;
        }
    }
}
