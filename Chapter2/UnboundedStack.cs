

namespace Chapter2
{
    public class UnboundedStack
    {
        public bool IsEmpty { get; set; } = true;

        public void Push(object item)
        {
            IsEmpty = false;
        }
    }
}
