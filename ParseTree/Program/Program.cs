// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ParseTree;

if (args.Length != 1)
{
    throw new ArgumentException("Incorrect number of arguments passed to program.");
}

string expression = File.ReadAllText(args[0]);

var tree = new ParseTree.Tree();

tree.Parse(expression);

var result = tree.Calculate();

Console.WriteLine($"result: {result}");
