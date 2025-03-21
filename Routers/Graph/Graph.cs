using System.Dynamic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Graph;

public class Graph()
{
    public Graph(int VerticesAmount) : this()
    {
        for (var i = 0; i < VerticesAmount; ++i)
        {
            this.vertices[this.VerticesAmount] = new Vertex(this.VerticesAmount);
        }
    }

    protected readonly Dictionary<int, Vertex> vertices = [];

    public int VerticesAmount {get => vertices.Count;}
    
    protected class Vertex(int number)
    {
        public int Number { get; } = number;
        public List<(Vertex vertex, int weight)> linked = [];
    }

    public void Link(int first, int second, int weight)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(first, this.VerticesAmount);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(second, this.VerticesAmount);

        this.vertices[first].linked.Add((this.vertices[second], weight));
        this.vertices[second].linked.Add((this.vertices[first], weight));
    }

    public void Unlink(int first, int second)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(first, this.VerticesAmount);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(second, this.VerticesAmount);

        if (this.vertices[first].linked.Find(x => x.vertex.Number == second) == default)
        {
            throw new InvalidOperationException("Vertices was never linked.");
        }

        this.vertices[first].linked.RemoveAt(second);
        this.vertices[second].linked.RemoveAt(first);
    }

    public int GetWeight(int first, int second)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(first, this.VerticesAmount);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(second, this.VerticesAmount);

        var (vertex, weight) = this.vertices[first].linked.Find(x => x.vertex.Number == second);
        
        if (vertex == default)
        {
            return -1;
        }

        return weight;
    }

    public List<(int vertex, int weight)> GetLinked(int number)
    {
        var result = new List<(int vertex, int weight)>();

        foreach (var (vertex, weight) in this.vertices[number].linked)
        {
            result.Add((vertex.Number, weight));
        }

        return result;
    }
}
