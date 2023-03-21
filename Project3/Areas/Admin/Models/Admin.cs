namespace Project3.Areas.Admin.Models
{
    public class Admin
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
