namespace MST;

using Routers;

public static class MST
{
    public static Dictionary<int, (int, int)> Build(string topology)
    {
        var graph = new Routers(topology);

        var isVisited = new Dictionary<int, bool>();

        var queue = new PriorityQueue<int, int>();

        var result = new Dictionary<int, (int otkyda, int weight)>();

        queue.Enqueue(0, 0);

        result[0] = (0, 0);

        while (queue.Count > 0)
        {
            var currentV = queue.Dequeue();

            isVisited[currentV] = true;

            foreach (var (linkedV, linkedW) in graph.GetLinked(currentV))
            {
                if (isVisited.ContainsKey(linkedV))
                {
                    continue;
                }
            
                queue.Enqueue(linkedV, linkedW);

                if (!result.ContainsKey(linkedV) || result[linkedV].weight < linkedW)
                {
                    result[linkedV] = (currentV, linkedW);
                }
                else if (result[currentV].weight < linkedW)
                {
                    result[currentV] = (linkedV, linkedW);
                }
            }
        }

        return result;
    }
}