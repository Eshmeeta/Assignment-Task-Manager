using System.ComponentModel.DataAnnotations;

namespace Assignment_Eshmeeta.Model
{
    public class Tasks
    {
        
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? Status { get; set; }

        
        
    }
}
