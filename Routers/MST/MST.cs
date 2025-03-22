namespace MST;

using Routers;

public static class MST
{
    public static Dictionary<(int, int), int> Build(string topology)
    {
        var graph = new Routers(topology);

        var isVisited = new bool[graph.VerticesAmount];

        var queue = new PriorityQueue<(int vertex, int weight), int>();

        var result = new Dictionary<(int first, int second), int>();

        for (var i = 0; i < graph.VerticesAmount; ++i)
        {
            for (var j = i; j < graph.VerticesAmount; ++j)
            {
                result[(i,j)] = 0;
            }
        }

        queue.Enqueue((0, 0), 0);

        while (queue.Count > 0)
        {
            var (currentV, currentW) = queue.Dequeue();

            isVisited[currentV] = true;

            foreach (var (linkedV, linkedW) in graph.GetLinked(currentV))
            {
                if (!isVisited[linkedV])
                {
                    queue.Enqueue((linkedV, linkedW), linkedW);

                    if (result[(currentV, linkedV)] < linkedW)
                    {
                        result[(currentV, linkedV)] = linkedW;
                        result[(linkedV, currentV)] = linkedW;
                    }
                }
            }
        }

        return result;
    }
}