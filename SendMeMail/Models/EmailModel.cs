namespace SendMeMail.Models
{
    /// <summary>
    /// This contains the form values used to send an email.
    /// </summary>
    public class EmailModel
    {
        public string? to { get; set; }
        public string? subject { get; set; }
        public string? body { get; set; }
    }
}
