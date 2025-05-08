using LZW;

Run(args);

static void Run(string[] args)
{
    if (args.Length != 2)
    {
        throw new ArgumentException("Incorrect number of arguments.");
    }

    ArgumentException.ThrowIfNullOrEmpty(args[0]);
    ArgumentException.ThrowIfNullOrEmpty(args[1]);

    switch (args[1])
    {
        case "--c":
            Compress(args[0]);
        break;
        case "--u":
            Decompress(args[0]);
        break;
        default:
            throw new ArgumentException("Invalid switch passed.");
    }
}

static void Compress(string path)
{
    var newFilePath = $"{path}.zipped";

    if (path.EndsWith(".txt"))
    {
        var input = File.ReadAllText(path);
        var result = LZW.CompressionWithBWT.Compress(input);
        File.WriteAllText(newFilePath, result);
    }
    else
    {
        var input = File.ReadAllBytes(path);
        var result = LZW.CompressionWithBWT.Compress(input);
        File.WriteAllBytes(newFilePath, result);
    }

    Console.WriteLine(GetCompressionRatio(path));
}

static void Decompress(string path)
{
    if (!path.EndsWith(".zipped"))
    {
        throw new ArgumentException("Invalid file format.");
    }

    var newFilePath = path[..path.LastIndexOf('.')];

    if (path.EndsWith(".txt.zipped"))
    {
        var input = File.ReadAllText(path);
        var result = LZW.Compression.Decompress(input);
        File.WriteAllText(newFilePath, result);
    }
    else
    {
        var input = File.ReadAllBytes(path);
        var result = LZW.Compression.Decompress(input);
        File.WriteAllBytes(newFilePath, result);
    }
}

static double GetCompressionRatio(string pathToInitialFile)
{
    var infoOfInitial = new FileInfo(pathToInitialFile);

    if (!infoOfInitial.Exists)
    {
        throw new FileNotFoundException("Initial file not found.");
    }

    var pathOfCompressed = $"{pathToInitialFile}.zipped";
    var infoOfCompressed = new FileInfo(pathOfCompressed);

    if (!infoOfCompressed.Exists)
    {
        throw new FileNotFoundException("Compressed file not found.");
    }

    return (double)infoOfInitial.Length / infoOfCompressed.Length;
}
