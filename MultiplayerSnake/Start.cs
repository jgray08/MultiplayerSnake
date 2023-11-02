namespace MultiplayerSnake;

public class Start
{
    public static int SelectDifficulty()
    {
        int difficulty = 5;
        while (difficulty == 5)
        {
            Console.WriteLine("Select your difficulty\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Easy\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2. Medium\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Hard\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("4. Impossible\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            var info = Console.ReadKey(true);
            switch (info.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("\nSelected difficulty easy");
                    difficulty = 1;
                    break;
                case ConsoleKey.D2:
                    Console.Write("\nSelected difficulty medium");
                    difficulty = 2;
                    break;
                case ConsoleKey.D3:
                    Console.Write("\nSelected difficulty hard");
                    difficulty = 3;
                    break;
                case ConsoleKey.D4:
                    Console.Write("\nSelected difficulty impossible");
                    difficulty = 4;
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        Thread.Sleep(1000);
        return difficulty;
    }
}