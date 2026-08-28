namespace MyRecipeBook.Communication.Response;

public class ResponseErrorJson
{
    public List<String> Errors { get; private set; }

    public ResponseErrorJson(List<string> errorMessages)
    {
        Errors = errorMessages;
    }

    public ResponseErrorJson(string errorMessage)
    {
        Errors = [errorMessage];
    }
}
