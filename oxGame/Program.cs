using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        char[,] spaces = new char[3, 3] {{' ',' ',' '}, {' ',' ',' '}, {' ',' ',' '}};
        char[,] InputSheet = new char[3, 3] {{'1','2','3'}, {'4','5','6'}, {'7','8','9'}};
        char playerOne = 'X', playerTwo = 'O';
        bool isRunning = true;
        string userInput, playerInput;
        

        Console.WriteLine("---Welcome to my noughts and crosses game---");

        Console.WriteLine("Player one will be cross(X) and Player two will be nought(O) \n");
        Console.WriteLine("Rules------");
        Console.WriteLine("1. To place your mark input, type in the corresponding position");
        Console.WriteLine("2. Respect each other this is a friendly game :)");
        Console.WriteLine("-----------------------------------------------");

        Console.WriteLine("Would you like to play the tutorial?");
        Console.Write("Input (Y/N): ");
        userInput = CheckInput(Console.ReadLine());

        do
        {

            if (userInput == "Y")
            {
                Tutorial();
                Game();
            }else if (userInput == "N")
            {
                Game();
            }else
            {
                Console.Write("Invalid input please input Y or N: ");
                userInput = CheckInput(Console.ReadLine());
                
                if (userInput == "Y")
                {
                    Tutorial();
                    Game();
                    

                }if (userInput == "N")
                { 
                    Game();
                }
                
            }
        
        }while(userInput !="Y" && userInput !="N" );



        Console.ReadLine();
    }
    

    public static char[,] DrawBoard(char[,] spaces,char mark = ' ')
    {   
        
        bool endGame =BoardStatus(spaces);
        if (endGame == true)
        {
            string player = mark=='X'? "Player One": "Player Two";    
            Console.WriteLine($"{player}'s Turn: \n");
        }
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[0,0]} | {spaces[0,1]} | {spaces[0,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[1,0]} | {spaces[1,1]} | {spaces[1,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[2,0]} | {spaces[2,1]} | {spaces[2,2]} ");
        Console.WriteLine("   |   |   \n");

        if (endGame == true)
        {
            Console.Write("where do you want to place your mark? (1-9): ");
        }
    
        return spaces;

    }
    public static string[,] DrawBoard(string[,] spaces,string mark)
    {   
        string player = mark=="X" ? "Player One": "Player Two";
       
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[0,0]} | {spaces[0,1]} | {spaces[0,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[1,0]} | {spaces[1,1]} | {spaces[1,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[2,0]} | {spaces[2,1]} | {spaces[2,2]} ");
        Console.WriteLine("   |   |   \n");

        return spaces;
    }
    public static void DrawBoard(string[,] spaces)
    {   
        
       
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[0,0]} | {spaces[0,1]} | {spaces[0,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[1,0]} | {spaces[1,1]} | {spaces[1,2]} ");
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {spaces[2,0]} | {spaces[2,1]} | {spaces[2,2]} ");
        Console.WriteLine("   |   |   \n");

    }

     public static void Tutorial()
    {   
        string[,] spaces = new string[3,3] {{"1","2","3"}, {"4","5","6"}, {"7","8","9"}};
        string[,] rowWin = new string[3,3] {{"1","2","3"}, {"X","X","X"}, {"7","8","9"}};
        string[,] rowLose = new string[3,3] {{"X","X","O"}, {"4","5","6"}, {"7","8","9"}};
        string[,] colWin = new string[3,3] {{"1","2","O"}, {"4","5","O"}, {"7","8","O"}};
        string[,] diaWin = new string[3,3] {{"X","2","3"}, {"4","X","6"}, {"7","8","X"}};
        string[,] dialose = new string[3,3] {{"1","2","X"}, {"4","O","6"}, {"X","8","9"}};
        string[,] tie = new string[3,3] {{"X","O","X"}, {"X","O","O"}, {"O","X","X"}};
        string mark = "X"; 
        string player = mark== "X" ? "Player One": "Player Two";
        string playerInput =" ";
        bool emptySpace = true;

        Console.Clear();

        Console.WriteLine("You have selected the TUTORIAL!!!!\n");
        Console.WriteLine("To play noughts and crosses on this software u need to input a");
        Console.WriteLine("number between 1 and 9 \n");

        DrawBoard(spaces,mark);

        Console.WriteLine("As you can see above each number represents a zone.");
        Console.WriteLine("of course during the game you will not see the numbers!\n");
        Console.WriteLine("But since we are still learning, we will have them appear throughout the tutorial :) \n");
        
        spaces = DrawBoard(spaces,mark);
        Console.Write("To set your mark input a postion. Now pick a zone and input its number: ");
        playerInput = Console.ReadLine();
        Console.WriteLine();

        spaces = EnterMark(playerInput,mark,spaces);

        spaces = DrawBoard(spaces,mark);
        Console.WriteLine("As you can see the zone you picked now has you mark meaning that you have claimed this position.");
        Console.WriteLine("The game will only end once Player One or Player two manages to claim an entire column or row");
        Console.WriteLine("The following boards show the win conditions: \n");

        Console.Write("Press enter to continue");
        Console.ReadLine();

        Console.WriteLine("The board below shows how to win the game by claiming all the cells in one row: \n");
        DrawBoard(rowWin);

        Console.WriteLine("But this is one of the three victory conditions. Your goal is to win whilst also preventing the other");
        Console.WriteLine("player from achieving a win by blocking his chances of claiming a row, column or a diagonal win \n");

        DrawBoard(rowLose);

        Console.WriteLine("The above board shows us how the other player could choose to block player one from achieving");
        Console.WriteLine("a win, the game is turn based so once a player enters his mark in one zone the other ");
        Console.Write("Player will also get a chance to do so as well until one player wins or if all zones are occupied,");
        Console.WriteLine("In that case the game would end in a draw! \n");

        Console.Write("Press enter to continue");
        Console.ReadLine();
        Console.WriteLine();

        DrawBoard(colWin);

        Console.WriteLine("An example of a column win \n");

        Console.Write("Press enter to continue");
        Console.ReadLine();
        Console.WriteLine();


        DrawBoard(diaWin);
        
        Console.WriteLine("Above: a win .... Below: a blocked attempt \n");

        DrawBoard(dialose);

        Console.Write("Press enter to continue");
        Console.ReadLine();

        Console.WriteLine("The board below is an example of a tie \n");

        DrawBoard(tie);

        Console.Write("Press enter to continue");
        Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("And that concludes the tutorial  :)");

        Console.ReadLine();
    }

    public static bool EmptySpaces (string[,] spaces)
    {
       bool emptySpace = true;
        
     /* for (int i = 0; i < 3; i ++)
        {
            for (int j = 0; j <3; j ++)
            emptySpace = spaces[i,j] == " " ? true :false;
        }
        */

        foreach(string space in spaces)
        {
            emptySpace = space != "X" ? true:false;
            emptySpace = space != "O" ? true:false;
        }

       return emptySpace;
    }

    public static string[,] EnterMark (string playerInput, string mark,string[,] spaces)
    {

        bool avaliableZone = true;
        foreach(string number in spaces)
        {
            if (number == "X" ||number == "O" )
            {
                Console.WriteLine("Sorry the zone is already taken ;-;");
                avaliableZone = false;
            }
        }

        if (avaliableZone == true)
        {

            switch (playerInput)
            {
                case "1":
                spaces[0,0] = mark;
                break;

                case "2":
                spaces[0,1] = mark;
                break;

                case "3":
                spaces[0,2] = mark;
                break;

                case "4":
                spaces[1,0] = mark;
                break;

                case "5":
                spaces[1,1] = mark;
                break;

                case "6":
                spaces[1,2] = mark;
                break;

                case "7":
                spaces[2,0] = mark;
                break;

                case "8":
                spaces[2,1] = mark;
                break;

                case "9":
                spaces[2,2] = mark;
                break;

                default:
                Console.WriteLine("invalid input");
                Console.Write("Input a number between 1 and 9: ");
                playerInput =Console.ReadLine();
                EnterMark(playerInput,mark,spaces);
                break;
            }
            
        }
            return spaces;
    }
    public static char[,] EnterMark (string playerInput, char mark,char[,] spaces)
    {
        bool isOccupied;
        switch (playerInput)
        {
            case "1":
            {
                isOccupied = IsOccupied(spaces,0,0);
                spaces = SetMark(isOccupied,spaces,mark,0,0);
            }
            break;

            case "2":
            {
                isOccupied = IsOccupied(spaces,0,1);
                spaces = SetMark(isOccupied,spaces,mark,0,1);
            }
            break;

            case "3":
            {
                isOccupied = IsOccupied(spaces,0,2);
                spaces = SetMark(isOccupied,spaces,mark,0,2);
            }
            break;

            case "4":
            {
                isOccupied = IsOccupied(spaces,1,0);
                spaces = SetMark(isOccupied,spaces,mark,1,0);
            }
            break;

            case "5":
            {
                isOccupied = IsOccupied(spaces,1,1);
                spaces = SetMark(isOccupied,spaces,mark,1,1);
            }
            break;

            case "6":
            {
                isOccupied = IsOccupied(spaces,1,2);
                spaces = SetMark(isOccupied,spaces,mark,1,2);
            }
            break;

            case "7":
            {
                isOccupied = IsOccupied(spaces,2,0);
                spaces = SetMark(isOccupied,spaces,mark,2,0);
            }
            break;

            case "8":
            {
                isOccupied = IsOccupied(spaces,2,1);
                spaces = SetMark(isOccupied,spaces,mark,2,1);
            }
            break;

            case "9":
            {
                isOccupied = IsOccupied(spaces,2,2);
                spaces = SetMark(isOccupied,spaces,mark,2,2);
            }
            break;

            default:
            Console.WriteLine("invalid input");
            Console.Write("Input a number between 1 and 9: ");
            playerInput =Console.ReadLine();
            EnterMark(playerInput,mark,spaces);
            break;
        }
            return spaces;
    }

    static bool IsOccupied (char[,] spaces, int a, int b)
    {
        bool isValid = true;
        string userInput = " ";
        bool isOccupied = true;

        if (spaces[a,b] != ' ')
        {
            Console.WriteLine("This zone is already occupied");
            Console.WriteLine("Please pick an empty zone (1-9)?");
            isOccupied = true;
           
        }else
        {
            isOccupied = false;
        }

        return isOccupied;
    }

    static char[,] SetMark (bool occupied,char[,] spaces, char mark,int a, int b)
    {
        string playerInput;
 
        if (occupied == false)
          {
            spaces[a,b] = mark;
          }else
          {
              Console.Write("Input: ");
              playerInput = Console.ReadLine();

              spaces = EnterMark(playerInput,mark,spaces);
            }

        return spaces;
    }

    static void GameStatus ()
    {
        
    }

    static bool isTie (char[,] spaces)
    {
        bool status = true;
        int space = 0;
        foreach(var zone in spaces)
        {
            if (zone == ' ')
            {
                space++;
            }
        }

        if (space > 0)
        {
            status = false;
        }else
        {
            
            status = true;
        }

        return status;
    }

    static bool isWin (char[,] spaces)
    {
        bool win = false;
        
        
        if (spaces[0,0] == spaces[0,1] && spaces[0,1] == spaces[0,2] && spaces[0,0] != ' ')
        {
            if(spaces[0,0] == 'X')
            {
                Console.WriteLine("Player One wins");
                win = true;

                return win;
            }else
            {
                Console.WriteLine("Player Two wins");
                win = true;

                return win;
            }
        }


        if (spaces[1,0] == spaces[1,1] && spaces[1,1] == spaces[1,2] && spaces[1,0] != ' ')
        {
            if(spaces[0,0] == 'X')
            {
                Console.WriteLine("Player One wins");
                win = true;

                return win;
            }else
            {
                Console.WriteLine("Player Two wins");
                win = true;

                return win;
            }
        }

        if (spaces[2,0] == spaces[2,1] && spaces[2,1] == spaces[2,2] && spaces[2,0] != ' ')
        {
            if(spaces[0,0] == 'X')
            {
                Console.WriteLine("Player One wins");
                win = true;

                return win;
            }else
            {
                Console.WriteLine("Player Two wins");
                win = true;

                return win;
            }
        }

        if( spaces[0,0] == spaces[1,0] && spaces[1,0] == spaces[2,0] && spaces[0,0] != ' ')
        {
             if(spaces[0,0] == 'X')
            {
                Console.WriteLine("Player One wins");
                win = true;

                return win;
            }else
            {
                Console.WriteLine("Player Two wins");
                win = true;

                return win;
            }
        }

        if( spaces[0,1] == spaces[1,1] && spaces[1,1] == spaces[2,1] && spaces[0,1] != ' ')
        {
             if(spaces[0,0] == 'X')
            {
                Console.WriteLine("Player One wins");
                win = true;

                return win;
            }else
            {
                Console.WriteLine("Player Two wins");
                win = true;

                return win;
            }
        }

        if( spaces[0,2] == spaces[1,2] && spaces[1,2] == spaces[2,2] && spaces[2,0] != ' ')
        {
             if(spaces[0,0] == 'X')
            {
                Console.WriteLine("Player One wins");
                win = true;

                return win;
            }else
            {
                Console.WriteLine("Player Two wins");
                win = true;

                return win;
            }
        }

        if( spaces[0,0] == spaces[1,1] && spaces[1,1] == spaces[2,2] && spaces[0,0] != ' ')
        {
             if(spaces[0,0] == 'X')
            {
                Console.WriteLine("Player One wins");
                win = true;

                return win;
            }else
            {
                Console.WriteLine("Player Two wins");
                win = true;

                return win;
            }
        }

        if( spaces[0,2] == spaces[1,1] && spaces[1,1] == spaces[2,0] && spaces[0,2] != ' ')
        {
             if(spaces[0,0] == 'X')
            {
                Console.WriteLine("Player One wins");
                win = true;

                return win;
            }else
            {
                Console.WriteLine("Player Two wins");
                win = true;

                return win;
            }
        }

        return win;

    }

     static string CheckInput(string input)
    {
        input = input.ToUpper();

        if (input == "Y")
        {
            return input;
        }else if (input== "N")
        {
            return input;
        }else
        {
            Console.Write("invalid input please enter (y or n): ");
            input = Console.ReadLine();
            CheckInput(input);
            return input;
        }
    }

    static bool BoardStatus(char[,] spaces)
    {
        bool isRunning = true;

        if(isTie(spaces) == true)
        {
            isRunning = false;
            
        };

        if (isWin(spaces) == true && isRunning == true)
        {
            isRunning = false;
        }

        return isRunning;
    }

    static void Game()
    {

        char[,] spaces = new char[3, 3] {{' ',' ',' '}, {' ',' ',' '}, {' ',' ',' '}};
        char[,] InputSheet = new char[3, 3] {{'1','2','3'}, {'4','5','6'}, {'7','8','9'}};
        char playerOne = 'X', playerTwo = 'O';
        bool isRunning = true;
        string userInput, playerInput;
        int turn = 0;

        Console.WriteLine("Entering game....");
        Console.WriteLine("You have entered the game");
        
        while(isRunning)
        {

            Console.WriteLine($"turn {turn + 1}");
            spaces = DrawBoard(spaces,playerOne);
            playerInput = Console.ReadLine();
            spaces = EnterMark(playerInput,playerOne,spaces);

            isRunning = BoardStatus(spaces);
            if(isRunning == false)
            {
                if(isTie(spaces) == true)
                {
                    Console.WriteLine("The Game ended in a Draw!!!");
                }

                DrawBoard(spaces);
                break;
            }

            Console.WriteLine();
            spaces = DrawBoard(spaces,playerTwo);
            playerInput = Console.ReadLine();
            spaces = EnterMark(playerInput,playerTwo,spaces);

            isRunning = BoardStatus(spaces);
            turn++;

           
        }

        Console.WriteLine("Would you like to play another game?");
        Console.Write("yes/no (Y/N): Y\b");
        userInput= CheckInput(Console.ReadLine());

        if(userInput=="Y")
        {
            Game();
        }else
        {
            Console.WriteLine("Thank you for playing my game!!");
            Console.ReadLine();

            Console.Clear();
            Environment.Exit(0);
        }

      
    }
}

