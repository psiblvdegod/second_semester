namespace MyList;

public interface INullRecognizer<T>
{
    public bool IsNull(T item);
}
