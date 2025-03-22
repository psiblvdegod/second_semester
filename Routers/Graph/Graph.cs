using System.Dynamic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Graph;

public class Graph()
{
    public Graph(string topology) : this()
    {
        foreach (var line in topology.Split('\n'))
        {
            var records = Array.ConvertAll(line.Split(' '), int.Parse);

            for (var i = 1; i + 1 < records.Length; i += 2)
            {
                this.Link(records[0], records[i], records[i + 1]);
            }
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
        if (!this.vertices.ContainsKey(first))
        {
            this.vertices[first] = new Vertex(first);
        }
        if (!this.vertices.ContainsKey(second))
        {
            this.vertices[second] = new Vertex(second);
        }

        this.vertices[first].linked.Add((this.vertices[second], weight));
        this.vertices[second].linked.Add((this.vertices[first], weight));
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
