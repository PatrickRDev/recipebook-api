using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Communication.Request;

public class RequestRegisterUserAccountJson
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } = string.Empty;
}
