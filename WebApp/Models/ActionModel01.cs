using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ActionModel01
    {
        [Required]
        [Range(1, 200)]
        public double? Weight { get; set; }

        [Required]
        [Range(1, 150)]
        public int? Age { get; set; }
    }
}