using Newtonsoft.Json;


namespace E_Voting_System.Models
{
    public class Location
    {
        [JsonProperty("ip")]
        public string IP { get; set; }
        public string Country_Code { get; set; }

        [JsonProperty("country_name")]
        public string Country_Name { get; set; }
        public string Region_Code { get; set; }

        [JsonProperty("region_name")]
        public string Region_Name { get; set; }
        
        [JsonProperty("city")]
        public string City { get; set; }
        
        public string Zip_Code { get; set; }

        [JsonProperty("time_zone")]
        public string Time_Zone { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

    }
}
