using Avalonia.Controls;

public abstract class Cell : Button, IFlag
{
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
                cell.IsFlagged = true;
                button.Content = "F";
            }
        }
    }

    public abstract void Reveal ( Button button );
}