namespace Telephony.Models
{
    using Interfaces;
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }

        //private bool ValidateNumber(string number)
        //{
        //    foreach (char digit in number)
        //    {
        //        if (!char.IsDigit(digit))
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}
    }
}
