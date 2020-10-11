namespace Kenbi.Domain.Models.AppSettings
{
    public class ApiEndpoints
    {
        public string BaseUrl { get; set; }
        public string ClientName { get; set; }
        public Challenge Challenge { get; set; }
    }

    public class Challenge
    {
        public string GetAuth { get; set; }
        public string GetUnAuth { get; set; }
        public string Post { get; set; }
    }
}
