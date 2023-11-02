using static System.Console;

namespace MultiplayerSnake;

public class Snake
{
    
    public ConsoleColor Color = ConsoleColor.Black;
    public int grow;
    public int x;
    public bool acceptinginput = true;
    public int y = Console.WindowHeight / 2;
    public int num;
    public string? direction = " ";
    public List<int[]> body;
    private int startingx = Console.WindowWidth / 2;
    public Snake(string player)
    {
        grow = -1;
        body = new List<int[]>();
        if (player == "1")
        {
            num = 1;
            direction = "left";
            x = startingx - 10;
            body.Add(new []{50, 15});
            body.Add(new []{51, 15});
            body.Add(new []{52, 15});
            body.Add(new []{53, 15});
            body.Add(new []{54, 15});
            body.Add(new []{55, 15});
        }
        else if (player == "2")
        {
            num = 2;
            direction = "right";
            x = startingx + 10;
            body.Add(new []{70, 15});
            body.Add(new []{69, 15});
            body.Add(new []{68, 15});
            body.Add(new []{67, 15});
            body.Add(new []{66, 15});
            body.Add(new []{65, 15});
        }
        string? tmp = "Black";
        while (Color == ConsoleColor.Black)
        {
            WriteLine($"Player {player} please select a color for your snake\n\n");
            ForegroundColor = ConsoleColor.Red;
            WriteLine("1 >> Red\n");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("2 >> Yellow\n");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("3 >> Green\n");
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("4 >> Blue\n");
            ForegroundColor = ConsoleColor.DarkMagenta;
            WriteLine("5 >> Purple\n");
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("6 >> Pink\n");
            ForegroundColor = ConsoleColor.White;
            WriteLine("7 >> White\n");
            ForegroundColor = ConsoleColor.Gray;
            var info = ReadKey(true);
            switch (info.Key)
            {
                case ConsoleKey.D1:
                    Color = ConsoleColor.Red;
                    tmp = Convert.ToString(Color);
                    break;
                case ConsoleKey.D2:
                    Color = ConsoleColor.Yellow;
                    tmp = Convert.ToString(Color);
                    break;
                case ConsoleKey.D3:
                    Color = ConsoleColor.Green;
                    tmp = Convert.ToString(Color);
                    break;
                case ConsoleKey.D4:
                    Color = ConsoleColor.Blue;
                    tmp = Convert.ToString(Color);
                    break;
                case ConsoleKey.D5:
                    tmp = "Purple";
                    Color = ConsoleColor.DarkMagenta;
                    break;
                case ConsoleKey.D6:
                    tmp = "Pink";
                    Color = ConsoleColor.Magenta;
                    break;
                case ConsoleKey.D7:
                    Color = ConsoleColor.White;
                    tmp = Convert.ToString(Color);
                    break;
                default:
                    Clear();
                    break;
            }
        }

        ForegroundColor = Color;
        Write($"\nPlayer {player} selected color {tmp}");
        ForegroundColor = ConsoleColor.Gray;
        Thread.Sleep(1000);
        Clear();
    }
}
