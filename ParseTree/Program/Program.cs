// <copyright file="Program.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

if (args.Length != 1)
{
    Console.WriteLine("Incorrect number of arguments passed to program.");
    return 1;
}

ParseTree.FileProcessing.Run(args[0]);

return 0;
