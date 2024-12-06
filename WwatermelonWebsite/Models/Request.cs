namespace WwatermelonWebsite.Models
{
    public class Request
    {
        // Primary Key
        public int Id { get; set; }

        // Email Address of the person making the request
        public string EmailAddress { get; set; }

        // The name of the brand that is being requested
        public string BrandRequest { get; set; }

        // A flag to indicate whether this is a correction request
        public bool IsCorrection { get; set; }

        // Details about the correction, if applicable
        public string CorrectionDetails { get; set; }
    }
}
