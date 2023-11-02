namespace MultiplayerSnake;

public class Renderer
{
    private static int frames;
    public static List<long> ProcessPerformance = new();
    public static List<long> RenderPerformance = new();
    public static List<int> SegmentPerformance = new();
    private static ConsoleColor[] CurrentRender = new ConsoleColor[Console.WindowHeight * Console.WindowWidth];
    private static ConsoleColor OldColor;
    private static readonly ConsoleColor DefaultColor = ConsoleColor.Black;
    private static int Segments;
    private static System.Text.StringBuilder Tempstring = new();
    private static readonly string[] SegmentContent = new string[Console.WindowHeight * Console.WindowWidth];
    private static readonly ConsoleColor[] SegmentColor = new ConsoleColor[Console.WindowHeight * Console.WindowWidth];

    public static void Process()
    {
        long PStart = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        Segments = 0;
        OldColor = CurrentRender[0];
        for (int i = 0; i < CurrentRender.Length; i++)
        {
            if (CurrentRender[i] == OldColor)
            {
                Tempstring.Append("\u2588");
            }
            else
            {
                SegmentContent[Segments] = Tempstring.ToString();
                SegmentColor[Segments] = OldColor;
                Tempstring.Clear();
                Tempstring.Append("\u2588");
                Segments++;
                OldColor = CurrentRender[i];
            }
            if (i == CurrentRender.Length - 1)
            {
                SegmentContent[Segments] = Tempstring.ToString();
                SegmentColor[Segments] = OldColor;
                Segments++;
                Tempstring.Clear();
                break;
            }
        }
        Tempstring.Clear();
        ProcessPerformance.Add(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - PStart);
        SegmentPerformance.Add(Segments);
        Render();
    }

    private static void Render()
    {
        frames++;
        long RStart = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        for (int i = 0; i < Segments; i++)
        {
            Console.ForegroundColor = SegmentColor[i];
            Console.Write($"{SegmentContent[i]}");
        }
        Console.SetCursorPosition(0, 0);
        RenderPerformance.Add(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - RStart);
    }

    public static void Clear(ConsoleColor color = ConsoleColor.Black)
    {
        for (int i = 0; i < CurrentRender.Length; i++)
        {
            CurrentRender[i] = color;
            OldColor = CurrentRender[0];
        }
    }

    public static void Inject(int location, ConsoleColor color)
    {
        if (location <= Console.WindowHeight * Console.WindowWidth)
        {
            CurrentRender[location] = color;
        }
    }
    
    public static void Point(int x, int y, ConsoleColor color)
    {
        if (y <= Console.WindowHeight)
        {
            if (x <= Console.WindowWidth)
            {
                CurrentRender[Utilities.Location(x, y)] = color;
            }
        }
    }

    public static void Init()
    {
        Console.Clear();
        for (int i = 0; i < CurrentRender.Length; i++)
        {
            CurrentRender[i] = DefaultColor;
            OldColor = CurrentRender[0];
        }
        for (int i = 0; i < 250; i++)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        }
    }

    public static void DrawLine(int x1, int y1, int x2, int y2, ConsoleColor color)
    {
        List<double[]> pointList = Utilities.PointsOnLine(x1, y1, x2, y2);
        foreach (var point in pointList)
        {
            Inject(Utilities.Location(Convert.ToInt32(point[0]), Convert.ToInt32(point[1])), color);
        }
    }

    public static void SendStats()
    {
        long psum = ProcessPerformance.Take(ProcessPerformance.Count).Sum();
        long pavg = psum / ProcessPerformance.Count; 
        long rsum = RenderPerformance.Take(RenderPerformance.Count).Sum();
        long ravg = rsum / RenderPerformance.Count;
        long savg = SegmentPerformance.Take(RenderPerformance.Count).Sum() / frames;
        
        Console.WriteLine($"Total frames rendered >> {frames}");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine($"Average process time >> {pavg}ms");
        Console.WriteLine($"Average render time >> {ravg}ms");
        Console.WriteLine($"Average segments per frame >> {savg}");
        Console.WriteLine("");
    }
}