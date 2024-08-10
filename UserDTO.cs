using Mockup.Components.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup;

public class UserDto
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Country { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public string? Password { get; set; }
    public bool isVerified { get; set; }

    static public UserDto equals(SignupModel x)
    {
        UserDto y = new UserDto();
        y.Name = x.Name;
        y.Country = x.Country;
        y.Email = x.Email;
        y.Role = x.Role;
        y.Password = x.Password;
        y.Surname = x.Surname;
        return y;
    }
}
