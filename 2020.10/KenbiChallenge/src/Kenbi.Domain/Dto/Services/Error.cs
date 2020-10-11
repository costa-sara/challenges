using Newtonsoft.Json;

namespace Kenbi.Domain.Dto
{
    public class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
