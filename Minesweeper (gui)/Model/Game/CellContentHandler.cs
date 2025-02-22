public class CellContentHandler
{
    private static readonly string _contentPath = "content/";

    public enum CellNumber
    {
        zero = 0,
        one = 1,
        two = 2,
        three = 3,
        four = 4,
        five = 5,
        six = 6,
        seven = 7,
        eight = 8
    }

    static public string SelectImage ( Cell cell )
    {
        if ( cell.IsFlagged )
            return _contentPath + "flag.png";

        if ( cell is Mine )
            return _contentPath + "mine.png";

        if ( cell is ClosedCell )
            return _contentPath + "closed.png";

        return $"{_contentPath}{(CellNumber) cell.NeighbourMines}.png";
    }

    static public double GetImageHeight ( Cell cell )
    {
        if ( cell is ClosedCell && !cell.IsFlagged )
            return Cell.Height;
        else
            return Cell.Height * 0.6;
    }

    static public double GetImageWidth ( Cell cell )
    {
        if ( cell is ClosedCell && !cell.IsFlagged )
            return Cell.Width;
        else
            return Cell.Width * 0.6;
    }
}