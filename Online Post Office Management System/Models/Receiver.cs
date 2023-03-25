using System.ComponentModel.DataAnnotations;
namespace Online_Post_Office_Management_System.Models
{
    public class Receiver
    {
        public int Id_Receiver { get; set; }
        [Required]
        public  int Receiver_Name { get; set; }
        public int Receiver_Address { get; set; }
        public int Phone { get; set; }
    }
}
