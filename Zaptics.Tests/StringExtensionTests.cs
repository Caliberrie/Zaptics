using Zaptics.Utilities;

namespace Zaptics.Tests
{
    internal class StringExtensionTests
    {
        [Test]
        public void ClampLength_Throws_UnderThreeMaxCharacters()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "1234".ClampLength(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => "1234".ClampLength(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => "1234".ClampLength(1));
            Assert.Throws<ArgumentOutOfRangeException>(() => "1234".ClampLength(2));
            Assert.DoesNotThrow(() => "1234".ClampLength(3));
        }

        [Test]
        public void ClampLength_IsCorrect_MaxLessThanValueLen()
        {
            Assert.AreEqual("abc...", "abcdefg".ClampLength(3));
        }

        [Test]
        public void ClampLength_IsCorrect_MaxGreaterThanValueLen()
        {
            Assert.AreEqual("abc", "abc".ClampLength(300));
        }

        [Test]
        public void ClampLength_IsCorrect_SameLen()
        {
            Assert.AreEqual("abc", "abc".ClampLength(3));
        }
    }
}