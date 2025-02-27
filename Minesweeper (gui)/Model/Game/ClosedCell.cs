using Avalonia.Controls;

public class ClosedCell : Cell
{
    public ClosedCell ( int x, int y, IFlagCount flagCounter, IMinefield minefield ) : base ( flagCounter, minefield )
    {
        Image = RevealImage ( this );

        _x = x;
        _y = y;
        _isFlagged = false;
        _neighbourMines = 0;
    }

    public override void LeftClick ( Button button, ISetDeadState IgameState )
    {
        base.LeftClick ( button, IgameState );
    }
}