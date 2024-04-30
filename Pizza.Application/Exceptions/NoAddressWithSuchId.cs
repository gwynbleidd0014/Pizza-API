namespace Pizza.Application.Exceptions;

public class NoAddressWithSuchId : CustomException
{
    public NoAddressWithSuchId(string msg) : base(msg)
    {

    }
}
