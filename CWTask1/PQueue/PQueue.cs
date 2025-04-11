// <copyright file="PQueue.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace PQueue;

/// <summary>
/// Implements PQueue data structure.
/// </summary>
/// <typeparam name="T">Type of elements in the Queue.</typeparam>
public class PQueue<T> : IPQueue<T>
{
    private BinaryHeap<T> elements = new();

    /// <inheritdoc/>
    public T Dequeue()
        => this.elements.GetMin();

    /// <inheritdoc/>
    public void Enqueue(T element, int priority)
       => this.elements.Add(element, priority);

    /// <inheritdoc/>
    public bool IsEmpty()
        => this.elements.IsEmpty();
}
