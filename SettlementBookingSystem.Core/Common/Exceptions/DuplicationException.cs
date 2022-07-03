namespace SettlementBookingSystem.Core.Common.Exceptions
{
    public class DuplicationException : ValidationException
    {
        public DuplicationException(string message) : base(message)
        {
        }
    }
}
