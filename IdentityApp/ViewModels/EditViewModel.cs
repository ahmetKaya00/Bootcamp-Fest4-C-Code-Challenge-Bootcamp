using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels{

    public class EditViewModel{

        public string? Id {get;set;}

        [Required]
        public string? FullName {get;set;}

        [Required]
        [EmailAddress]
        public string? Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string? Password {get;set;} 

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Parola eşleşmedi.")]
        public string? ConfirmPassword {get;set;}

        public IList<string>? SelectedRoles {get;set;}
    }
}