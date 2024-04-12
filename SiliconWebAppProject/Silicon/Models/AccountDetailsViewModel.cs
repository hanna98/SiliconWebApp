using Infrastructure.Models.Users;

namespace Silicon.Models;

public class AccountDetailsViewModel
{
    public AccountBasicInfo BasicInfo { get; set; } = null!;
    public AccountAddressInfo AddressInfo { get; set; } = null!;
}
