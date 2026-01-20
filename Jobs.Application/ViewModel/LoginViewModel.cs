namespace Jobs.Application.ViewModel;

public class LoginViewModel
{
    public string Token { get; set; }

    public LoginViewModel(string token)
    {
        Token = token;
    }
}
