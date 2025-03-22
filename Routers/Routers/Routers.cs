namespace Routers;

using Graph;

public class Routers : Graph 
{
    public Routers(string topology) : base()
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

    public string GetTopology()
    {
        var result = string.Empty;

        for (var i = 0; i < this.VerticesAmount; ++i)
        {
            result += $"{i}";

            foreach (var (vertex, weight) in this.vertices[i].linked)
            {
                result += $" {vertex.Number} {weight}";
            }

            result += "\n";
        }

        return result;
    }
}
