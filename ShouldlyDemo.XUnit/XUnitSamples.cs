using System;
using Shouldly;
using Xunit;

namespace ShouldlyDemo.XUnit
{
    public class XUnitSamples
    {
        [Fact]
        public void _1_BooleanAssertion()
        {
            var response = new {IsSuccessStatusCode = false};
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public void _2_EqualsAssertion()
        {
            var response = new {StatusCode = 404};
            Assert.Equal(response.StatusCode, 200);
        }

        [Fact]
        public void _4_BooleanAssertionShouldly()
        {
            var response = new { IsSuccessStatusCode = false };
            
            response.IsSuccessStatusCode.ShouldBeTrue();
        }

        [Fact]
        public void _5_EqualsAssertionShouldly()
        {
            var response = new { StatusCode = 404 }; 
            
            response.StatusCode.ShouldNotBe(404);
        }

        class Throws
        {
            public void GetResult() => throw new AccessViolationException();
        }

        [Fact]
        public void _6_ExceptionAssertion()
        {
            var sut = new Throws();

            Should.Throw<BadImageFormatException>(sut.GetResult);
        }

        
        [Fact]
        public void _7_MultipleAssertions()
        {
            var response = new { StatusCode = 503 };
            var repository = new {RecordCount = 7};
            var logs = new {Entries = new[] {new {Message = "Failed"}}};

            response.ShouldSatisfyAllConditions
            (
                () => response.StatusCode.ShouldBe(200),
                () => repository.RecordCount.ShouldBe(2),
                () => logs.Entries.ShouldContain(e => e.Message == "Success")
            );
        }

        [Fact]
        public void ArrayAssertion()
        {
            var x = new[] { 3, 4, 5 };

            x.ShouldContain(6);
        }
    }
}
