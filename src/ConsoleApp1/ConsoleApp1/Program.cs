public interface INumber
{
    object NumericValue { get; set; }
}

public class Number : INumber
{
    public object NumericValue { get; set; }
}

public interface INumber<T>
{
    T NumericValue { get; set; }
}

public class Number<T> : INumber<T>
{
    public Number(T value)
    {
        NumericValue = value;
    }

    public T NumericValue { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var intHolder = new Number<int?>(null); // T is int?, which can be null
        var stringHolder = new Number<string>("Hello"); // T is string
        var objectHolder = new Number<object>(new object()); // T is object
        var nullableHolder = new Number<int?>(5); // T is int?, with a value

        Console.WriteLine(intHolder.NumericValue); // Output: null
        Console.WriteLine(stringHolder.NumericValue); // Output: Hello
        Console.WriteLine(objectHolder.NumericValue); // Output: System.Object
        Console.WriteLine(nullableHolder.NumericValue); // Output: 5
    }
}
