using System;
using Xunit;

public class NumberTests
{
    [Fact]
    public void IntHolder_ShouldAllowNullableInt()
    {
        // Arrange
        var intHolder = new Number<int?>(null);

        // Act
        var result = intHolder.NumericValue;

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void StringHolder_ShouldStoreStringValue()
    {
        // Arrange
        var stringHolder = new Number<string>("Hello");

        // Act
        var result = stringHolder.NumericValue;

        // Assert
        Assert.Equal("Hello", result);
    }

    [Fact]
    public void ObjectHolder_ShouldStoreObjectValue()
    {
        // Arrange
        var obj = new object();
        var objectHolder = new Number<object>(obj);

        // Act
        var result = objectHolder.NumericValue;

        // Assert
        Assert.Equal(obj, result);
    }

    [Fact]
    public void NullableHolder_ShouldStoreNullableIntValue()
    {
        // Arrange
        var nullableHolder = new Number<int?>(5);

        // Act
        var result = nullableHolder.NumericValue;

        // Assert
        Assert.Equal(5, result);
    }
}
