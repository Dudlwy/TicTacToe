using System.Globalization;
using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        char[,] spaces = new char[3, 3] {{' ',' ',' '}, {' ',' ',' '}, {' ',' ',' '}};
        char playerOne = 'X', playerTwo = 'O';

        Console.WriteLine("---Welcome to my noughts and crosses game---");

        Console.WriteLine("Player one will be cross(X) and Player two will be nought(O) \n");
        Console.WriteLine("Rules------");
        Console.WriteLine("1. To place your mark input, type in the corresponding position");
        Console.WriteLine("tp for top left");


        DrawBoard(spaces,playerOne);
        DrawBoard(spaces,playerTwo);

        Tutorial();
    }

    public static void DrawBoard(char[,] spaces,char mark)
    {   
        string player = mark=='X'? "Player One": "Player Two";
        Console.WriteLine($"{player}'s Turn: \n");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[0,0]} | {spaces[0,1]} | {spaces[0,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[1,0]} | {spaces[1,1]} | {spaces[1,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine($" {spaces[2,0]} | {spaces[2,1]} | {spaces[2,2]} ");
        Console.WriteLine("   |   |   \n");
    }

     public static void Tutorial()
    {   
        string[,] spaces = new string[3,3] {{"tl","t","tr"}, {"l","c","r"}, {"bl","b","br"}};
        string mark = "X"; 
        string player = mark== "X" ? "Player One": "Player Two";
        string playerInput =" ";
        bool emptySpace = true;

        while(emptySpace)
        {
             Console.WriteLine($"{player}'s Turn: \n");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[0,0]} | {spaces[0,1]} | {spaces[0,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[1,0]} | {spaces[1,1]} | {spaces[1,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine($" {spaces[2,0]} | {spaces[2,1]} | {spaces[2,2]} ");
        Console.WriteLine("   |   |   \n");

        Console.Write("To set your mark input a postion e.g tp: ");
        playerInput = Console.ReadLine();

        

        Console.WriteLine($"{player}'s Turn: \n");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[0,0]} | {spaces[0,1]} | {spaces[0,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[1,0]} | {spaces[1,1]} | {spaces[1,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine($" {spaces[2,0]} | {spaces[2,1]} | {spaces[2,2]} ");
        Console.WriteLine("   |   |   \n");

        emptySpace = EmptySpaces(spaces);
        }
    }

    public static bool EmptySpaces (string[,] spaces)
    {
       bool emptySpace = true;
        
      for (int i = 0; i < spaces.Length; i ++)
        {
            for (int j = 0; j <spaces.Length; j ++)
            emptySpace = spaces[i,j] == " " ? true :false;
        }

       return emptySpace;
    }
}

