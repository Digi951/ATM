using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UserInputDto
    {
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

        [Required]
        [Display(Name = "Balance")]
        [Range(-1000, 1000000, ErrorMessage = "Balance must be between -1000 and 1,000,000!")]
        public decimal Balance { get; set; }
    }
}