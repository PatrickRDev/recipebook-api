namespace MyRecipeBook.Communication.Response;

public class ResponseRegisterUserJson
{
    public string Name { get; set; } = string.Empty;
    public ResponseTokensJson Tokens { get; set; } = new ResponseTokensJson();


}
