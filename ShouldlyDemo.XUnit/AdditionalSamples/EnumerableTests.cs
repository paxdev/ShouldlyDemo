using System;
using Shouldly;
using Xunit;

namespace ShouldlyDemo.XUnit.AdditionalSamples;

public class EnumerableTests
{
    private class TestClass
    {
        public TestClass(int value)
        {
            Value = value;
        }
        public int Value { get; }
    }


    private readonly string[] _names;
    private readonly TestClass[] _objects;

    public EnumerableTests()
    {
        _names = new[]
        {
            "Alan",
            "Bob",
            "Charlie",
            "Charlie"
        };

        _objects = new[]
        {
            new TestClass(1),
            new TestClass(2)
        };
    }

    [Fact]
    public void ShouldBeUnique()
    {
        _names.ShouldBeUnique();
    }

    [Fact]
    public void ShouldContain()
    {
        _names.ShouldContain("Dave");
    }

    [Fact]
    public void ShouldBeOneOf()
    {
        "Charlie".ShouldNotBeOneOf(_names);
    }

    [Fact]
    public void ShouldAllBe()
    {
        _objects.ShouldAllBe(s => s.Value == 1);
    }


    [Fact]
    public void ShouldBeInOrder()
    {
        _names.ShouldBeInOrder(SortDirection.Descending, /* Optional IComparer */ StringComparer.OrdinalIgnoreCase);
    }

    [Fact]
    public void ShouldBeSubsetOf()
    {
        new[] { "David" }.ShouldBeSubsetOf(_names);
    }
}