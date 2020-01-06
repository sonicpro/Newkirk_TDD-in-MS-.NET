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
            var top = Peek();
            items.RemoveAt(items.Count - 1);
            return top;
        }

        public object Peek()
        {
            if (!IsEmpty)
            {
                return items[items.Count - 1];
            }
            else
            {
                throw new InvalidOperationException("Stack is Empty");
            }
        }
    }
}
