using System;
using System.Collections;

namespace Chapter2
{
    public class UnboundedStack
    {
        private readonly ArrayList items = new ArrayList();

        public bool IsEmpty => items.Count == 0;

        public void Push(object item)
        {
            items.Add(item);
        }

        public object Pop()
        {
            if (!IsEmpty)
            {
                var topIndex = items.Count - 1;
                var top = items[topIndex];
                items.RemoveAt(topIndex);
                return top;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public object Peek()
        {
            return items[items.Count - 1];
        }
    }
}
