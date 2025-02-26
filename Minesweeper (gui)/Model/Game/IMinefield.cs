public interface IMinefield
{
    int Width { get; }
    int Height { get; }
    int Mines { get; }
    Cell[,] Cells { get; }
}