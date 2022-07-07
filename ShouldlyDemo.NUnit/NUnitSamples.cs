using NUnit.Framework;

namespace ShouldlyDemo.NUnit
{
    public class NUnitSamples
    {

        [Test]
        public void _3_EqualsAssertion()
        {
            var response = new { StatusCode = 404 };
            Assert.That(response.StatusCode, Is.Not.EqualTo(404));
        }
    }
}