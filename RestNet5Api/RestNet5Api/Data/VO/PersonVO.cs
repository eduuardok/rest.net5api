using System.Text.Json.Serialization;

namespace RestNet5Api.Data.VO
{
    public class PersonVO
    {
        [JsonPropertyName("code")]
        public long Id {get; set;}
        [JsonPropertyName("name")]
        public string FirstName { get; set; }
        [JsonIgnore]
        public string LastName { get; set; }
        [JsonIgnore]
        public string Address { get; set; }
        [JsonPropertyName("sexo")]
        public string Gender { get; set; }
        [JsonIgnore]
        public string CompleteName { get; set; }
    }
}