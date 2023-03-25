using System.ComponentModel.DataAnnotations;
namespace Online_Post_Office_Management_System.Models
{
    public class Postage
    {
        public int Id_Postage { get; set; }
        [Required]
        public int Weight { get; set; }
        public int Expense { get; set; }
        public int Id_Receiver { get; set; }
        public int Id_Service { get; set; }
        public Boolean Status { get; set; }
    }
}
