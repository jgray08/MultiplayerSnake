namespace MultiplayerSnake;

public class Food
{
    public static List<int[]> locations = new List<int[]>();
    public static void Generate()
    {
        Random rnd = new Random();
        int rx = rnd.Next(1, Console.WindowWidth);
        int ry = rnd.Next(1, Console.WindowHeight);
        locations.Add(new []{rx, ry});
    }
}