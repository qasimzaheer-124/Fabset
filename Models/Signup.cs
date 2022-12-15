using System;
using System.ComponentModel.DataAnnotations;

namespace fabset_project.Models
{
    public class Signup
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [RegularExpression("^[a-z0-9_-]{3,16}$")]
        [MinLength(3,ErrorMessage ="User name must be greater than or equal to 3 characters")]
        public string? Username { get; set; }
        [Required]
        [RegularExpression("^([a-z0-9_\\.\\+-]+)@([\\da-z\\.-]+)\\.([a-z\\.]{2,6})$", ErrorMessage = "Incorrect email address")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [Compare("Retype",ErrorMessage = "Passwords do not match")]
        [MinLength(6,ErrorMessage = "Password must be greater than 5 characters")]
        public string? Password { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must be greater than 5 characters")]
        public string? Retype { get; set; }
        [Required]
        public DateTime Dof { get; set; }
    }
}
