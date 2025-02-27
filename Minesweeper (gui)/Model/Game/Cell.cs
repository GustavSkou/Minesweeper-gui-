using Avalonia.Controls;
public abstract class Cell : IClickable
{
    private IFlagCount _flagCounter;
    private IMinefield _minefield;

    protected int _x, _y, _neighbourMines;
    protected bool _isFlagged;
    protected Button _buttonInstance;

    public static double Height = 40;  
    public static double Width = 40;

    public int X { get { return _x; } } // currently not in use
    public int Y { get { return _y; } } // currently not in use

    public Button ButtonInstance
    {
        get { return _buttonInstance; }
        set { _buttonInstance = value; }
    }
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

    public Cell ( IFlagCount flagCounter, IMinefield minefield)
    {
        _isFlagged = false;
        _minefield = minefield;
        _flagCounter = flagCounter;
    }

    public virtual void LeftClick ( Button button, ISetDeadState IgameState )
    {
        if ( button.Tag is Cell cell )
        {
            if ( cell.IsFlagged || cell is OpenCell )
                return;

            button.Tag = new OpenCell ( cell, _flagCounter, _minefield );

            if ( cell._neighbourMines > 0 )
            {
                cell.Image = RevealImage ( ( (OpenCell) button.Tag ) );
                button.Content = Image;
            }
            else
            {
                button.Content = " ";
                OpenSurroundingCells ( button );
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
            _flagCounter.Up ();
            button.Content = cell.Image;
        }
        else
        {
            if (_flagCounter.Count > 0)
            {
                cell.IsFlagged = true;
                _flagCounter.Down ();
                button.Content = RevealImage( cell );
            }
            else
            {
                return;
            }
        }
    }

    public virtual void LeftAndRightClick( Button button )
    { }

    protected void OpenSurroundingCells( Button button )
    {
        if (button.Tag is Cell cell)
        {
            if ( cell.NeighbourMines == 0 )
            {
                for (int rowIndex = cell.X - 1; rowIndex <= cell.X + 1; rowIndex++ )
                {
                    // Check out of range
                    if ( rowIndex < 0 || rowIndex >= _minefield.Height )
                        continue;

                    for (int columnIndex = cell.Y - 1; columnIndex <= cell.Y + 1; columnIndex++ )
                    {
                        // Skip itself
                        if ( rowIndex == cell.X && columnIndex == cell.Y )    
                            continue;

                        // Check out of range
                        if ( columnIndex < 0 || columnIndex >= _minefield.Width )
                            continue;

                        if ( _minefield.Cells[rowIndex, columnIndex] is OpenCell )
                            continue;

                        Cell surroundingCell = _minefield.Cells [rowIndex, columnIndex];    
                        surroundingCell.LeftClick ( surroundingCell.ButtonInstance, null );
                    }
                }
            }
        }
    }

    protected Image RevealImage ( Cell cell )
    {
        return CellImage.SelectImage(cell);
    }
}