using System.ComponentModel.DataAnnotations; // Importing DataAnnotations namespace for validation attributes

namespace CRUD_Using_Repository.Models
{
    // User class: Represents a user entity, with properties for UserId, Name, Gender, Email, PinCode, and IsActive.
    public class User
    {
        // UserId: This is the primary key of the User entity.
        [Key]
        public int UserId { get; set; }

        // Name: A required field, with a custom error message if not provided. This stores the user's name.
        [Required(ErrorMessage = "pls! Enter your Name")]
        public string Name { get; set; } = default!; // Using default! to ensure that the property is initialized to a non-null default.

        // Gender: A required field that stores the user's gender.
        [Required]
        public string Gender { get; set; } = default!;

        // Email: A required field that stores the user's email address.
        [Required]
        public string Email { get; set; } = default!;

        // PinCode: A required field that stores the user's postal pin code. The Display attribute customizes the label displayed in forms.
        [Display(Name = "Pin Code")]
        [Required]
        public int PinCode { get; set; }

        // IsActive: A boolean flag that indicates whether the user is active. The Display attribute customizes the label displayed in forms.
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
