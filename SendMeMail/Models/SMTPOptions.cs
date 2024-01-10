namespace SendMeMail.Models
{
    /// <summary>
    /// Contains SMTP options populated from the environment specific appsettings.json file.
    /// </summary>
    public class SMTPOptions
    {
        public string? Host { get; set; }
        public int Port{ get; set; }
    }
}
