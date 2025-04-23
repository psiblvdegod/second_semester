using System.ComponentModel;

namespace Calculator;

public interface ICalculator<T> : INotifyPropertyChanged
{
    public void AddToken(char token);

    public string State { get; }

    public static Dictionary<char, Func<T,T,T>>? ValidOperations { get; }
}
