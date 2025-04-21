namespace Calculator;

public interface ICalculator
{
    public void AddToken(char token);

    public double Value { get; }
}
