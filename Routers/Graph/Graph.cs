// <copyright file="Graph.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace Graph;

/// <summary>
/// Implements data structure "Graph".
/// </summary>
public class Graph()
{
    private readonly Dictionary<int, Vertex> vertices = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Graph"/> class using data from topology.
    /// </summary>
    /// <param name="topology">Topology which will be used to build graph.</param>
    public Graph(string topology)
        : this()
    {
        ValidateTopology(topology);

        foreach (var line in topology[..^1].Split('\n'))
        {
            var edge = line.Split(' ').Select(int.Parse).ToArray();

            this.Link(edge[0], edge[1], edge[2]);
        }
    }

    /// <summary>
    /// Gets amount of vertices in the graph.
    /// </summary>
    public int VerticesAmount { get => this.vertices.Count; }

    /// <summary>
    /// Links specified vertices.
    /// </summary>
    /// <param name="first">Number of first vertex.</param>
    /// <param name="second">Number of second vertex.</param>
    /// <param name="weight">Weight of the edge witch will connect vertices.</param>
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

        this.vertices[first].Linked.RemoveAll(x => x.Vertex.Number == second);
        this.vertices[second].Linked.RemoveAll(x => x.Vertex.Number == first);

        this.vertices[first].Linked.Add((this.vertices[second], weight));
        this.vertices[second].Linked.Add((this.vertices[first], weight));
    }

    /// <summary>
    /// Gets list of tuples where first element is the number of linked vertex and second is the weight of the edge linking them.
    /// </summary>
    /// <param name="number">Number of vertex which list of linked vertices you want to get.</param>
    /// <returns>Returns vertices linked with specified one and weight of edges connecting them.</returns>
    /// <exception cref="ArgumentException">Throws if vertex, passed as argument, does not exist.</exception>
    public List<(int Vertex, int Weight)> GetLinked(int number)
    {
        if (!this.vertices.ContainsKey(number))
        {
            throw new ArgumentException("vertex does not exist");
        }

        var result = new List<(int Vertex, int Weight)>();

        foreach (var (vertex, weight) in this.vertices[number].Linked)
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

    private class Vertex(int number)
    {
        public List<(Vertex Vertex, int Weight)> Linked = [];

        public int Number { get; } = number;
    }
}
