namespace POST.Models
{
    public class Payment
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Amount { get; set; }
        public ICollection<Shipping> Shippings { get; set; }
    }
}
