namespace ECommerce.Domain.Exceptions
{
    public class ConfirmationException : ApplicationException
    {
        public ConfirmationException()
        {

        }
        public ConfirmationException(string message) : base(message)
        {

        }
    }
}
