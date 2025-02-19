using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System.Collections.Generic;

public abstract class Cell : IFlag
{
    protected string _contentPath = "content/";

    protected int _x, _y, _neighbourMines;
    protected bool _isFlagged;

    public static int Height = 20;  
    public static int Width = 20;

    public int X { get { return _x; } } // currently not in use
    public int Y { get { return _y; } } // currently not in use

    public int NeighbourMines 
    { 
        get { return _neighbourMines; } 
        set { _neighbourMines = value; } 
    }
    public bool IsFlagged               // could we use the iFlag of this ?!
    {
        get { return _isFlagged; }
        set { _isFlagged = value; }
    }
    public Image Image { get; set; }


    protected Dictionary<int, string> NumberStringpairs = new Dictionary<int, string>
    {
        {0, "zero" },
        {1, "one" },
        {2, "two" },
        {3, "three" },
        {4, "four" },
        {5, "five" },
        {6, "six" },
        {7, "seven" },
        {8, "eight" }
    };

    public virtual void LeftClick ( Button button )
    {
        if ( button.Tag is Cell cell )
        {
            if ( cell.IsFlagged || cell is OpenCell)
                return;
            
            button.Tag = new OpenCell ( cell );
            
            try
            {
                button.Content = GetImage ( (OpenCell) button.Tag );
            }
            catch
            {
                button.Content = " ";
            }            
        }
    }

    public virtual void RightClick ( Button button )
    {
        if ( button.Tag is not Cell cell || button.Tag is OpenCell )
            return;

        button.Tag = cell;

        if ( cell.IsFlagged )
        {
            cell.IsFlagged = false;
            button.Content = " ";
        }
        else
        {
            cell.IsFlagged = true;
            button.Content = GetImage(cell);
        }
    }

    public virtual void LeftAndRightClick( Button button)
    { }

    protected Image GetImage ( Cell cell )
    {
        var image = new Image
        {
            Source = new Bitmap( SelectImage( cell ) ),
            Width = GetImageWidth(cell),
            Height = GetImageHeight(cell)
        };
        return image;
    }

    protected string SelectImage ( Cell cell )
    {
        if ( cell.IsFlagged )
            return _contentPath + "flag.png";

        if ( cell is Mine )
            return _contentPath + "mine.png";

        if ( cell is ClosedCell)
            return _contentPath + "closed.png";
        
        return $"{_contentPath}{NumberStringpairs[cell.NeighbourMines]}.png";
    }

    protected double GetImageHeight(Cell cell)
    {
        if (cell is ClosedCell)
            return Height;
        else
            return Height * 0.6;
    }

    protected double GetImageWidth(Cell cell)
    {
        if (cell is ClosedCell)
            return Width;
        else
            return Width * 0.6;
    }
}