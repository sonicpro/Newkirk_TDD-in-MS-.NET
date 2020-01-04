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
            stack.Push(new { field = 1 });
            Assert.IsFalse(stack.IsEmpty, "After Push, IsEmpty should be false");
        }
    }
}
