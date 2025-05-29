#pragma warning disable


public class Calc2
{
    private static readonly double Epsilon = 0.00001;

    private double? accumulator = null;

    public double? Value => accumulator;

    private _Operation operation = _Operation.Null;

    public void Clean()
    {
        this.accumulator = null;
        this.operation = _Operation.Null;
    }

    public void AddOperand(double operand)
    {
        // left operand
        if (this.accumulator is null && this.operation == _Operation.Null)
        {
            this.accumulator = operand;
        }

        // prefix unary
        else if (this.accumulator is null && this.operation != _Operation.Null)
        {
            this.accumulator = GetUnary(this.operation)(operand);
            this.operation = _Operation.Null;
        }

        // right operand
        else if (this.operation != _Operation.Null)
        {
            this.accumulator = GetBinary(this.operation)((double)this.accumulator, operand);
            this.operation = _Operation.Null;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void AddUnary(_Operation operation)
    {
        if (this.operation != _Operation.Null)
        {
            throw new InvalidOperationException();
        }

        // prefix unary
        if (this.accumulator == null)
        {
            this.operation = operation;
        }

        // postfix unary
        else
        {
            this.accumulator = GetUnary(operation)((double)this.accumulator);
            this.operation = _Operation.Null;
        }
    }

    public void AddBinary(_Operation operation)
    {
        if (this.accumulator is null || this.operation != _Operation.Null)
        {
            throw new InvalidOperationException();
        }

        this.operation = operation;
    }

    private static Func<double, double> GetUnary(_Operation operation) => operation switch
    {
        _Operation.Floor => Math.Floor,
        _Operation.Ceiling => Math.Ceiling,
        _ => throw new(),
    };

    private static Func<double, double, double> GetBinary(_Operation operation) => operation switch
    {
        _Operation.Addition => (x, y) => x + y,
        _Operation.Substraction => (x, y) => x - y,
        _Operation.Multiplication => (x, y) => x * y,
        _Operation.Division => (x, y) => Math.Abs(y) < Epsilon ? throw new() : x / y,
        _ => throw new(),
    };
}
