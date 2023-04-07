namespace POST.Models
{
    public class Shipping
    {
        public string Origin { get; set; }
        public int Id { get; set; }
        public string Destination { get; set; }
        public string DeliveryOption { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public int Shipping_Category { get; set; }
        public string Image_Path { get; set; }
        

    }
}
