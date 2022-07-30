using _01_Query.Contracts;

namespace _01_Query.Query
{
    public class TempData : ITempData
    {
        public string Message { get; set; }

        public void Set(string value)
        {
            Message = value;
        }

        public string Get()
        {
            return Message;
        }
    }
}
