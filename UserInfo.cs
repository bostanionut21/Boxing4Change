using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup;

public class UserInfo
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public UserInfo(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
}