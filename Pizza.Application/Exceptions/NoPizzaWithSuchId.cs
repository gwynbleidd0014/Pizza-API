namespace Pizza.Application.Exceptions;

public class NoPizzaWithSuchId : CustomException
{
    public NoPizzaWithSuchId(string msg) : base(msg)
    {

    }
}
