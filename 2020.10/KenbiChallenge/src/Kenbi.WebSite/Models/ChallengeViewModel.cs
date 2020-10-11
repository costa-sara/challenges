

using System.ComponentModel.DataAnnotations;

namespace Kenbi.WebSite.Models
{
    public class ChallengeViewModel
    {
        [Display(Name = "Unprotected")]
        public string UnprotectedData { get; set; }

        [Display(Name = "Protected")]
        public string ProtectedData { get; set; }

        public bool? Success { get; set; }
    }
}
