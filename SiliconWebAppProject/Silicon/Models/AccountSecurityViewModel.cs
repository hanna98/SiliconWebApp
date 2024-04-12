using Infrastructure.Models.Users;

namespace Silicon.Models;

public class AccountSecurityViewModel
{
    public ChangePasswordForm ChangePassword { get; set; } = null!;
    public DeleteForm Delete { get; set; } = null!;
}
