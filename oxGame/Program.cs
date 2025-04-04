using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        char[,] spaces = new char[3, 3] {{' ',' ',' '}, {' ',' ',' '}, {' ',' ',' '}};

        DrawBoard(spaces);
    }

    public static void DrawBoard(char[,] spaces)
    {   
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[0,0]} | {spaces[0,1]} | {spaces[0,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[1,0]} | {spaces[1,1]} | {spaces[1,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine($" {spaces[2,0]} | {spaces[2,1]} | {spaces[2,2]} ");
        Console.WriteLine("   |   |   ");
    }
}

