namespace Calculator;

public interface ICalculator
{
    public void AddToken(char token);

    public string State { get; }
}
