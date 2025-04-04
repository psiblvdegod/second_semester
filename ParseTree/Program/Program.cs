// <copyright file="Program.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

using ParseTree;

if (args.Length != 1)
{
    Console.WriteLine("Incorrect number of arguments passed to program.");
    return 1;
}

string expression;

try
{
    expression = File.ReadAllText(args[0]);
}
catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException)
{
    Console.WriteLine("Argument \"path\" passed to method is invalid.");
    return 2;
}
catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
{
    Console.WriteLine("File was not found.");
    return 3;
}

Tree expressionAsParseTree;

try
{
    expressionAsParseTree = new Tree(expression);
}
catch (InvalidExpressionException ex)
{
    Console.WriteLine("Expression in file is invalid.");
    Console.WriteLine(ex.Message);
    return 4;
}

var result = expressionAsParseTree.Calculate();

Console.WriteLine($"result: {result}");

return 0;
