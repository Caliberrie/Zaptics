using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaptics.Utilities;

namespace Zaptics.Tests
{
    [TestFixture]
    public class FlagExtensionTests
    {
        public enum TestFlag
        {
            NoValue  = 1,
            ValueOne = 1 << 1,
            ValueTwo = 1 << 2,
        }

        [Test]
        public void AddFlag_Works()
        {
            var enumValue = TestFlag.NoValue;
            enumValue.AddFlag(TestFlag.ValueOne);
            Assert.IsTrue(enumValue.HasFlag(TestFlag.ValueOne));
        }

        [Test]
        public void RemoveFlag_Works()
        {
            var enumValue = TestFlag.NoValue;
            enumValue.AddFlag(TestFlag.ValueOne);
            Assert.IsTrue(enumValue.HasFlag(TestFlag.ValueOne));
            enumValue.RemoveFlag(TestFlag.ValueOne);
            Assert.IsFalse(enumValue.HasFlag(TestFlag.ValueOne));
        }
    }
}
