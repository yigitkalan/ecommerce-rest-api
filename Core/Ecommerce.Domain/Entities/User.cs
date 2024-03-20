using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain;
public class User: IdentityUser<Guid>
{
    public string? RefreshToken {get; set;}
    public DateTime? RefreshTokenExpiryTime {get; set;}

}
