namespace POST.Models
{
    public class Shipment
    { 
        public int Id { get; set; }
        public string Infor { get; set; }
        public DateTime Date_Receive { get; set; }
        public Boolean Status { get; set; }
        public string Delivered_By  { get; set; }
        public ICollection<Shipping> Shippings { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
