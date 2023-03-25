using System.ComponentModel.DataAnnotations;
namespace Online_Post_Office_Management_System.Models
{
    public class Call
    {
        public int Id_Call { get; set; }
        [Required]
        public float Calling_Number { get; set; }
        public int Quantity { get; set; }

        public decimal Freight { get; set; }
        public int Id_Server { get; set; }
    }
}
