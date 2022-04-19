namespace MVCWebApplication.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        //public bool? Success { get; set; } = false;
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
