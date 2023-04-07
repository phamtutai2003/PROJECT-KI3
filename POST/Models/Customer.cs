namespace POST.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean Status { get; set; }
        public ICollection<Shipping> Shippings { get; set; }
    }
}
