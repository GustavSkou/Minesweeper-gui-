using Avalonia.Controls;

public class ClosedCell : Cell
{
    public ClosedCell ( int x, int y )
    {
        Image = GetImage ( this );

        _x = x;
        _y = y;
        _isFlagged = false;
        _neighbourMines = 0;
    }

    public override void LeftClick ( Button button )
    {
        base.LeftClick ( button );
    }


}