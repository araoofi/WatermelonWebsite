using System.ComponentModel.DataAnnotations;

namespace WwatermelonWebsite.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string BrandRequest { get; set; }

        public bool IsCorrection { get; set; }

        public string? CorrectionDetails { get; set; }

        public string? DateAdded {get; set;}
        public string? Status {get; set;}
    }
}
