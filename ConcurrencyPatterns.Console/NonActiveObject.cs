namespace ConcurrencyPatterns.Console;

public class NonActiveObject
{
    private int _value;

    public override string ToString() 
        => $"{Environment.CurrentManagedThreadId} has value: {_value}";

    public void Increase() => ++_value;

    public void Decrease() => --_value;
}
