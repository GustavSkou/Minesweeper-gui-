using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;

public abstract class Cell : Button, IFlag
{
    private string _contentPath = "C:/Users/gusta/Documents/GitHub/Minesweeper-gui-/Minesweeper (gui)/content/flag.png";


    protected int _x, _y, _neighbourMines;
    protected bool _isMine, _isFlagged, _isRevealed;
    protected string _symbol;



    public int X { get { return _x; } }
    public int Y { get { return _y; } }
    public bool IsRevealed 
    { 
        get { return _isRevealed; } 
        set { _isRevealed = value; }
    }
    public string Symbol
    {
        get { return _symbol; }
        set { _symbol = value; }
    }
    public int NeighbourMines 
    { 
        get { return _neighbourMines; } 
        set { _neighbourMines = value; } 
    }
    public bool IsFlagged
    {
        get { return _isFlagged; }
        set { _isFlagged = value; }
    }

    public virtual void Flag ( Button button )
    {
        if ( button.Tag is Cell cell )
        {
            if ( button.Tag is OpenCell )
                return;

            if ( cell.IsFlagged )
            {
                cell.IsFlagged = false;
                button.Content = " ";
            }
            else
            {
                var image = new Image
                {
                    Source = new Bitmap("content/flag.png"),
                    Width = button.Width - 8,
                    Height = button.Height - 8
                };

                cell.IsFlagged = true;
                button.Content = image;
            }
        }
    }

    public abstract void Reveal ( Button button );
}