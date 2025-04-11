// <copyright file="IPQueue.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace PQueue;

/// <summary>
/// Describes Priority queue data structure.
/// </summary>
/// <typeparam name="T">Type of elements in the queue.</typeparam>
public interface IPQueue<T>
{
    /// <summary>
    /// Gets element with minimum priority.
    /// </summary>
    /// <returns>Value of this element.</returns>
    public T Dequeue();

    /// <summary>
    /// Adds elements with specified priority.
    /// </summary>
    /// <param name="element">Value of this element.</param>
    /// <param name="priority">Priority of the element.</param>
    public void Enqueue(T element, int priority);

    /// <summary>
    /// Returns if the queue empty.
    /// </summary>
    /// <returns>true if queue is empty; otherwise false.</returns>
    public bool IsEmpty();
}
