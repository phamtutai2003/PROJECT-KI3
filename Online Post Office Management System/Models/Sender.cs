using System.ComponentModel.DataAnnotations;
namespace Online_Post_Office_Management_System.Models
{
    public class Sender
    {
        public int Id_Sender { get; set; }
        [Required]
        public int Name_Sender { get; set; }
        public int Address { get; set; }
        public int Phone { get; set; }
    }
}
