
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Online_Post_Office_Management_System.Models
{
    public class Type_Of_Service
    {
        public int Id_Server { get; set; }
        public int Service_Name { get; set; }
    }
}
