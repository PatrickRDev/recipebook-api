using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Communication.ExceptionsBase;

public class ErrorOnValidationException : MyRecipeBookException
{
    private readonly List<string> _errors;
    public ErrorOnValidationException(List<string> errorsMessages)
    {
        _errors = errorsMessages;
    }

    public List<string> GetErrorMessages() => _errors;
}
