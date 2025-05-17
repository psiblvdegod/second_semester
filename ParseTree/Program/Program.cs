// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ParseTree;

if (args.Length != 1)
{
    throw new ArgumentException("Incorrect number of arguments passed to program.");
}

string expression = File.ReadAllText(args[0]);

var expressionAsParseTree = new Tree(expression);

var result = expressionAsParseTree.Calculate();

Console.WriteLine($"result: {result}");
