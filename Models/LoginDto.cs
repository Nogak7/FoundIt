namespace FoundIt.Models;

public class LoginDto
{
    public string UserName { get; set; }
    public string Pasword { get; set; }

    public LoginDto(string usrn , string pass)
    {
        UserName = usrn;
        Pasword = pass;
    }


 }

