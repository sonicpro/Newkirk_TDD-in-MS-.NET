using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chapter2;

namespace UnboundedStackTest
{
    [TestClass]
    public class StackFixture
    {
        private UnboundedStack stack;

        [TestInitialize]
        public void Init()
        {
            stack = new UnboundedStack();
        }

        [TestMethod]
        public void Empty()
        {
            Assert.IsTrue(stack.IsEmpty);
        }

        [TestMethod]
        public void PushOne()
        {
            stack.Push(new { Field = 1 });
            Assert.IsFalse(stack.IsEmpty, "After Push, IsEmpty should be false");
        }

        [TestMethod]
        public void PushOnePopOne()
        {
            stack.Push(new { Field = 1 });
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty, "After Push - Pop, IsEmpty should be true");
        }

        [TestMethod]
        public void PushPopContentCheck()
        {
            var expected = 1234;
            stack.Push(expected);
            var actual = (int)stack.Pop();
            Assert.AreEqual(expected, actual, "The object should not be modified when pushed to and popped from stack");
        }

        [TestMethod]
        public void PushPopMultipleElements()
        {
            var firstElement = 1234;
            var secondElement = 2345;
            var thirdElement = 3456;
            stack.Push(firstElement);
            stack.Push(secondElement);
            stack.Push(thirdElement);
            var popped = (int)stack.Pop();
            Assert.AreEqual(thirdElement, popped);
            popped = (int)stack.Pop();
            Assert.AreEqual(secondElement, popped);
            popped = (int)stack.Pop();
            Assert.AreEqual(firstElement, popped);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Must throw InvalidOperationException if popping the empty stack")]
        public void PopEmptyStack()
        {
            stack.Pop();
        }

        [TestMethod]
        public void PushOneAndPeek()
        {
            stack.Push(new { Field = 1 });
            stack.Peek();
            Assert.IsFalse(stack.IsEmpty);
        }

        [TestMethod]
        public void PushPeekContentCheck()
        {
            var item = 1234;
            stack.Push(item);
            var actual = (int)stack.Peek();
            Assert.AreEqual(item, actual, "The pushed item should be available through Peek()");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Must throw InvalidOperationException if executing Peek() on empty stack")]
        public void PeekEmptyStack()
        {
            stack.Peek();
        }
    }
}
