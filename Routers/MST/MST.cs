// <copyright file="MST.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace MST;

using Graph;

/// <summary>
/// Implements Prim algorithm.
/// </summary>
public static class MST
{
    /// <summary>
    /// Builds MST using Prim's algorith.
    /// </summary>
    /// <param name="topology">Topology of the initial graph.</param>
    /// <returns>Topology of the MST of initial graph and it`s total length.</returns>
    /// <exception cref="InvalidTopologyException">Throws if graph can not be built correctly using passed topology.</exception>
    public static (string MST, int TotalLength) Build(string topology)
    {
        var graph = new Graph(topology);
        var isVisited = new Dictionary<int, bool>();
        var queue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        var result = new Dictionary<int, (int Linked, int Weight)>();

        var start = int.Parse(topology[..topology.IndexOf(' ')]);
        queue.Enqueue(start, 0);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            isVisited[current] = true;

            foreach (var (linked, weight) in graph.GetLinked(current))
            {
                if (isVisited.ContainsKey(linked))
                {
                    continue;
                }

                queue.Enqueue(linked, weight);

                if (!result.ContainsKey(linked) || result[linked].Weight < weight)
                {
                    result[linked] = (current, weight);
                }
                else if (result[current].Weight < weight)
                {
                    result[current] = (linked, weight);
                }
            }
        }

        if (graph.VerticesAmount != isVisited.Count)
        {
            throw new InvalidTopologyException("graph with given topology is disconnected.");
        }

        var resultAsTopology = DictionaryToTopology(result);

        return (resultAsTopology, GetTotalLength(resultAsTopology));

        static string DictionaryToTopology(Dictionary<int, (int Linked, int Weight)> dictionary)
        {
            var output = string.Empty;

            foreach (var record in dictionary.OrderBy(x => x.Value.Linked))
            {
                output += $"{record.Value.Linked} {record.Key} {record.Value.Weight}\n";
            }

            return output;
        }

        static int GetTotalLength(string topology)
        {
            var result = 0;

            foreach (var line in topology[..^1].Split('\n'))
            {
                result += int.Parse(line.Split(' ')[^1]);
            }

            return result;
        }
    }
}
