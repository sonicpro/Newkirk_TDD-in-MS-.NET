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

        [TestMethod]
        public void PushMultiplePeekAndVerifyTheLastPushed()
        {
            var firstItem = 1234;
            stack.Push(firstItem);
            var secondItem = 2345;
            stack.Push(secondItem);
            var thirdItem = 3456;
            stack.Push(thirdItem);
            var actual = (int)stack.Peek();
            Assert.AreEqual(thirdItem, actual, "Peek() must return the last pushed item");
        }

        [TestMethod]
        public void PushPeekNoStackStateChange()
        {
            var item = 44;
            stack.Push(item);
            object top = null;
            for (int i = 0; i != 10; i++)
            {
                top = (int)stack.Peek();
                Assert.AreEqual(item, top);
            }
        }

        [TestMethod]
        public void PushNull()
        {
            stack.Push(null);
            Assert.IsFalse(stack.IsEmpty);
        }

        [TestMethod]
        public void PushNullPopCheckContent()
        {
            stack.Push(null);
            var item = stack.Pop();
            Assert.IsNull(item, "Nulls must be stored explicitly in the stack");
        }

        [TestMethod]
        public void PushNullPeekContentCheck()
        {
            stack.Push(null);
            var item = stack.Peek();
            Assert.IsNull(item, "Peek() must make it possible to peek null values");
        }
    }
}
