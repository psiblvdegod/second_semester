namespace Graph;

public class InvalidTopologyException : System.Exception
{
    public InvalidTopologyException() : base() {}

    public InvalidTopologyException(string Message) : base(Message) {}
    
    public InvalidTopologyException(string Message, Exception inner) {}
}
