using Pizza.Application.Exceptions;

namespace Pizza.Application.Services.Exceptions;

public class ResourceNotFound : CustomException
{
    public ResourceNotFound(string msg) : base(msg)
    {
        
    }
}
