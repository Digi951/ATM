using System.ComponentModel.DataAnnotations;

public class UserModel
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "First Name")]
    [MinLength(2, ErrorMessage = "First Name must be 2 characters or longer!")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    [MinLength(2, ErrorMessage = "Last Name must be 2 characters or longer!")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Invalid Email Address!")]
    public string Email { get; set; }
}