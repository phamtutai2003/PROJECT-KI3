namespace POST.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public ICollection<Personnel> Personnel { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
