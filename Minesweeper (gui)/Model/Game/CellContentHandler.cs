using Avalonia.Controls;
using Avalonia.Media.Imaging;

public static class CellImage
{
    private static readonly string _contentPath = "content\\";

    public static Image One
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "one.png" ),
                Height = Cell.Height * _margin,
                Width = Cell.Width * _margin
            };
        }
    }
    public static Image Two
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "two.png" ),
                Height = Cell.Height * _margin,
                Width = Cell.Width * _margin
            };
        }
    }
    public static Image Three
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "three.png" ),
                Height = Cell.Height * _margin,
                Width = Cell.Width * _margin
            };
        }
    }
    public static Image Four
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "four.png" ),
                Height = Cell.Height * _margin,
                Width = Cell.Width * _margin
            };
        }
    }
    public static Image Five
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "five.png" ),
                Height = Cell.Height * _margin,
                Width = Cell.Width * _margin
            };
        }
    }
    public static Image Six
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "six.png" ),
                Height = Cell.Height * _margin,
                Width = Cell.Width * _margin
            };
        }
    }
    public static Image Seven
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "seven.png" ),
                Height = Cell.Height * _margin,
                Width = Cell.Width * _margin
            };
        }
    }
    public static Image Eight
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "eight.png" ),
                Height = Cell.Height * _margin,
                Width = Cell.Width * _margin
            };
        }
    }

    public static Image Open
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "open.png" ),
                Height = Cell.Height,
                Width = Cell.Width
            };
        }
    }
    public static Image Closed
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "closed.png" ),
                Height = Cell.Height,
                Width = Cell.Width
            };
        }
    }
    public static Image Flag
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "flag.png" ),
                Height = Cell.Height * _margin,
                Width = Cell.Width * _margin
            };
        }
    }
    public static Image Mine
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "mine.png" ),
                Height = Cell.Height * _margin,
                Width = Cell.Width * _margin
            };
        }
    }

    private static readonly double _margin = 0.6;

    static public Image SelectImage ( Cell cell )
    {
        if ( cell.IsFlagged )
            return Flag;

        if ( cell is Mine )
            return Mine;

        if ( cell is ClosedCell )
            return Closed;

        return cell.NeighbourMines switch
        {
            0 => Open,
            1 => One,
            2 => Two,
            3 => Three,
            4 => Four,
            5 => Five,
            6 => Six,
            7 => Seven,
            8 => Eight,
            _ => Open
        };        
    }

    private enum CellNumber
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
}