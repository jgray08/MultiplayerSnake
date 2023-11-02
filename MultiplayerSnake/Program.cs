namespace MultiplayerSnake;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Please set console to fullscreen for best experience");
        //Thread.Sleep(2500);
        Console.Clear();
        Console.CursorVisible = false;
        Game.Begin();
    }
}