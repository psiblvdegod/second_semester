using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Graph;

public class Graph()
{
    public Graph(string topology) : this()
    {
        ValidateTopology(topology);

        foreach (var line in topology[..^1].Split('\n'))
        {
            var edge = line.Split(' ').Select(int.Parse).ToArray();

            this.Link(edge[0], edge[1], edge[2]);
        }
    }

    protected readonly Dictionary<int, Vertex> vertices = [];

    public int VerticesAmount { get => vertices.Count; }

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

        this.vertices[first].linked.RemoveAll(x => x.vertex.Number == second);
        this.vertices[second].linked.RemoveAll(x => x.vertex.Number == first);

        this.vertices[first].linked.Add((this.vertices[second], weight));
        this.vertices[second].linked.Add((this.vertices[first], weight));
    }

    public List<(int vertex, int weight)> GetLinked(int number)
    {
        if (!this.vertices.ContainsKey(number))
        {
            throw new ArgumentException("vertex does not exist");
        }

        var result = new List<(int vertex, int weight)>();

        foreach (var (vertex, weight) in this.vertices[number].linked)
        {
            result.Add((vertex.Number, weight));
        }

        return result;
    }

    private static void ValidateTopology(string topology)
    {
        if (string.IsNullOrWhiteSpace(topology))
        {
            throw new InvalidTopologyException("topology is empty or null");
        }

        if (topology[^1] != '\n')
        {
            throw new InvalidTopologyException("line-break character at the end is missing.");
        }

        foreach (var line in topology[..^1].Split('\n'))
        {
            var edge = line.Split(' ');

            if (edge.Length != 3)
            {
                throw new InvalidTopologyException($"{line} cannot be recognized as an edge.");
            }

            foreach (var operand in edge)
            {
                if (!int.TryParse(operand, out _))
                {
                    throw new InvalidTopologyException($"{operand} cannot be recognised as a number of vertex or as a weight of edge.");
                }
            }
        }
    }
}
