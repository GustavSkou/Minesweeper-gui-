public class GameSettings
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int Mines { get; set; }

    public GameSettings ( int width, int height, int mines )
    {
        Width = width;
        Height = height;
        Mines = mines;
    }
}