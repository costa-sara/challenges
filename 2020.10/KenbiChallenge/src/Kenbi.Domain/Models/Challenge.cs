using System;

namespace Kenbi.Domain.Models
{
    public class Challenge
    {
        public string Id { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
