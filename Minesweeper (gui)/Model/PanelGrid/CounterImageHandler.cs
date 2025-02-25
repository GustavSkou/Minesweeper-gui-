using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;

public static class CounterImageHandler
{
    private static readonly string _contentPath = "content\\counter_image\\";
    private static readonly double _margin = 1;

    public static Image Zero
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "zero.png" ),
                Height = Cell.Height * _margin,
                Margin = new Thickness ( 0 )
            };
        }
    }
    public static Image One
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "one.png" ),
                Height = Cell.Height * _margin,
                Margin = new Thickness ( 0 )
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
                Margin = new Thickness ( 0 )
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
                Margin = new Thickness ( 0 )
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
                Margin = new Thickness ( 0 )
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
                Margin = new Thickness ( 0 )
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
                Margin = new Thickness ( 0 )
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
                Margin = new Thickness ( 0 )
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
                Margin = new Thickness ( 0 )
            };
        }
    }

    public static Image Nine
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "nine.png" ),
                Height = Cell.Height,
                Margin = new Thickness ( 0 )
            };
        }
    }

    public static Image GetImage ( int number )
    {
        return (CellNumber) number switch
        {
            CellNumber.zero => Zero,
            CellNumber.one => One,
            CellNumber.two => Two,
            CellNumber.three => Three,
            CellNumber.four => Four,
            CellNumber.five => Five,
            CellNumber.six => Six,
            CellNumber.seven => Seven,
            CellNumber.eight => Eight,
            _ => Nine
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
