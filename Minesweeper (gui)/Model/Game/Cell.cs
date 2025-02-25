using Avalonia.Controls;

public abstract class Cell : IClickable
{
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

    public virtual void LeftClick ( Button button )
    {
        if ( button.Tag is Cell cell )
        {
            if ( cell.IsFlagged || cell is OpenCell )
                return;

            button.Tag = new OpenCell ( cell );

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
            button.Content = cell.Image;
        }
        else
        {
            cell.IsFlagged = true;
            button.Content = RevealImage( cell );
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
                    if ( rowIndex < 0 || rowIndex >= Minefield.Instance.Height )
                        continue;

                    for (int columnIndex = cell.Y - 1; columnIndex <= cell.Y + 1; columnIndex++ )
                    {
                        // Skip itself
                        if ( rowIndex == cell.X && columnIndex == cell.Y )    
                            continue;

                        // Check out of range
                        if ( columnIndex < 0 || columnIndex >= Minefield.Instance.Width )
                            continue;

                        if ( Minefield.Instance.Cells[rowIndex, columnIndex] is OpenCell )
                            continue;

                        Cell surroundingCell = Minefield.Instance.Cells [rowIndex, columnIndex];    
                        surroundingCell.LeftClick ( surroundingCell.ButtonInstance );
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