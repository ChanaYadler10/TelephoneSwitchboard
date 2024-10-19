namespace UI.Models
{
    public class AlertViewModel
    {
        public string AlertType { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Resolved { get; set; }
    }
}
