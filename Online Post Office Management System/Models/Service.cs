using System.ComponentModel.DataAnnotations;
namespace Online_Post_Office_Management_System.Models
{
    public class Service
    {
        public int Id_Service { get; set; }
        [Required]
        public int Id_receiver{ get; set; }
        public int Id_Sender { get; set; }
        public int Weight { get; set; }
        public decimal Price { get; set; }
        public int Name_Service { get; set; }
    }
}
