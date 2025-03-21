namespace Routers;

using Graph;
using Microsoft.VisualBasic;

public class Routers : Graph 
{
    public Routers() : base() {}

    public Routers(int RoutersAmount) : base(RoutersAmount) {}

    public Routers(string topology) : this()
    {
        var lines = topology.Split('\n');

        for (var i = 0; i < lines.Length; ++i)
        {
            this.Add();
        }

        foreach (var line in lines)
        {
            var records = Array.ConvertAll(line.Split(' '), int.Parse);

            var vertex = records[0];

            for (var i = 1; i + 1 < records.Length; i += 2)
            {
                this.Link(vertex, records[i], records[i + 1]);
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
