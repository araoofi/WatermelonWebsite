using System.ComponentModel.DataAnnotations;

namespace WwatermelonWebsite.Models
{
    public class RequestModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string BrandRequest { get; set; }

        public bool IsCorrection { get; set; }

        public string? CorrectionDetails { get; set; }
    }
}
