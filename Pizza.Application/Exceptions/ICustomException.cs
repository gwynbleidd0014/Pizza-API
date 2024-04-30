namespace Pizza.Application.Exceptions
{
    public abstract class CustomException : Exception
    {
        protected CustomException(string msg) : base(msg)
        {
            
        }
    }
}
