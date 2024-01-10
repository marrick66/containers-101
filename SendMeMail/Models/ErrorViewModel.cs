namespace SendMeMail.Models
{
    /// <summary>
    /// Used for the displaying of any errors in the shared Error view.
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
