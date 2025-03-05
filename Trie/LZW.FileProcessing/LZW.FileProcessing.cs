using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

namespace LZW.FileProcessing;

public static class FileProcessing
{
    private static (string, char) ProcessInput(string[] args)
    {
        var key = '\0';

        if (args[1] == "-c")
        {
            key = 'c';
        }
        else if (args[1] == "-u")
        {
            key = 'u';
        }
        else
        {
            throw new ArgumentException("Invalid value.");
        }
        
        var data = string.Empty;
        try
        {
            data = File.ReadAllText(args[0]);
        }
        catch (PathTooLongException)
        {
            throw new ArgumentException("Path is too long.");
        }
        catch (DirectoryNotFoundException)
        {
            throw new ArgumentException("Directory not found.");
        }
        catch (FileNotFoundException)
        {
            throw new ArgumentException("File not found.");
        }

        return (data, key);
    }

    public static void StartProgram()
    {
        Console.WriteLine("LZW is running");
        Console.WriteLine("Enter file path and key (-c to compress, -u to decompress)");
        Console.WriteLine("Example: ./text.txt -c");
        var data = string.Empty;
        var key = '\0';
        try
        {
            (data, key) = GetInput();
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }

        var output = string.Empty;

        if (key == 'c')
        {
            try
            {
                output = LZW.Compress(data);
            }
            catch
            {
            }
        }
        
    }
}
