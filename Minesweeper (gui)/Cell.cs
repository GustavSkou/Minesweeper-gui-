using Avalonia.Controls;

public class Cell : Button , IFlag
{
    protected int _x, _y, _neighbourMines;
    protected bool _isMine, _isFlagged, _isRevealed;
    protected char _symbol;

    public int X { get { return _x; } }
    public int Y { get { return _y; } }
    public bool IsRevealed 
    { 
        get { return _isRevealed; } 
        set { _isRevealed = value; }
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
    

    public Cell (int x, int y)
    {
        _x = x;
        _y = y;

        _symbol = '0';

        _isMine = false;
        _isFlagged = false;
        _isRevealed = false;
        _neighbourMines = 0;
    }

    public virtual void Reveal (Button button)
    {
        if (button.Tag is Cell cell )
        {
            if ( cell.IsFlagged || cell.IsRevealed ) //maybe _isRevealed is not necessary
                return;

            cell.IsRevealed = true;
            button.Content = cell._symbol;
            button.IsEnabled = false;
        }
    }

    public void Flag(Button button)
    {
        if ( button.Tag is Cell cell )
        {
            if ( cell.IsRevealed ) 
                return;

            if ( cell.IsFlagged )
            {
                cell.IsFlagged = false;
                button.Tag = ;
                button.Content = " ";
            }
            else
            {
                cell.IsFlagged = true;
                button.Content = "F";
            }
        }
    }
}