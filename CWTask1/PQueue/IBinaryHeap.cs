// <copyright file="IBinaryHeap.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace PQueue;

/// <summary>
/// Describes binary heap data structure.
/// </summary>
/// <typeparam name="T">Type of elements in the heap.</typeparam>
public interface IBinaryHeap<T>
{
    /// <summary>
    /// Gets element with minimum priority.
    /// </summary>
    /// <returns>Element with minimum priority.</returns>
    public T GetMin();

    /// <summary>
    /// Adds element to PQueue.
    /// </summary>
    /// <param name="data">Value of new element.</param>
    /// <param name="priority">Priority of new element.</param>
    public void Add(T data, int priority);

    /// <summary>
    /// Returns if queue is empty.
    /// </summary>
    /// <returns>true if empty is empty; otherwise false.</returns>
    public bool IsEmpty();
}
