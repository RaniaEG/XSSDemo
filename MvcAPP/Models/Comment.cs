using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
    public class Comment
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "Only alphanumeric characters and underscores are allowed.")]
        public string Username { get; set; }
        public string Text { get; set; }
    }
}