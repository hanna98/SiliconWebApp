using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Users;

public class DeleteForm
{
    [Display(Name = "Yes, I want to delete my account.")]
    public bool DeleteAccount { get; set; }
}
