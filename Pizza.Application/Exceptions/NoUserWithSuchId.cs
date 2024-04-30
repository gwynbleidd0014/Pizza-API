using Pizza.Application.Exceptions;

namespace Pizza.Application.Services.Exceptions;

public class NoUserWithSuchId : CustomException
{
    public NoUserWithSuchId(string msg) : base(msg)
    {
        
    }
}
