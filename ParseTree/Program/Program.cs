// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

if (args.Length != 1)
{
    throw new ArgumentException("Incorrect number of arguments passed to program.");
}

string expression = File.ReadAllText(args[0]);

var tree = new ParseTree.Tree();

tree.Parse(expression);
tree.Print();
Console.WriteLine();

var result = tree.Calculate();

Console.WriteLine($"result: {result}");
