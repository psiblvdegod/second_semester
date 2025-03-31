namespace ParseTree;

public static class FileProcessing
{
    public static void Run(string path)
    {
        string expression;

        try
        {
            expression = File.ReadAllText(path);
        }
        catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException) 
        {
            Console.WriteLine("File was not found.");
            return;
        }
        catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException)
        {
            Console.WriteLine("Argument \"path\" passed to method is invalid.");
            return;
        }

        ParseTree.Tree expressionAsParseTree;

        try
        {
            expressionAsParseTree = new ParseTree.Tree(expression);
        }
        catch (InvalidExpressionException ex)
        {
            Console.WriteLine("Expression in file is invalid.");
            Console.WriteLine(ex.Message);
            return;
        }

        var result = expressionAsParseTree.Calculate();

        Console.WriteLine($"result: {result}");
    }
}
