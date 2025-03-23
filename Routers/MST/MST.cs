namespace MST;

using System.Security.Cryptography.X509Certificates;
using Graph;

public static class MST
{
    public static (string MST, int totalLength) Build(string topology)
    {
        var graph = new Graph(topology);
        var isVisited = new Dictionary<int, bool>();
        var queue = new PriorityQueue<int, int>(Comparer<int>.Create((x,y) => y.CompareTo(x)));
        var result = new Dictionary<int, (int linked, int weight)>();

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

                if (!result.ContainsKey(linked) || result[linked].weight < weight)
                {
                    result[linked] = (current, weight);
                }
                else if (result[current].weight < weight)
                {
                    result[current] = (linked, weight);
                }
            }
        }

        var MST = DictionaryToTopology(result);

        return (MST, GetTotalLength(MST));

        static string DictionaryToTopology(Dictionary<int, (int linked, int weight)> dictionary)
        {
            var output = string.Empty;

            foreach (var record in dictionary.OrderBy(x => x.Value.linked))
            {
                output += $"{record.Value.linked} {record.Key} {record.Value.weight}\n";
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