using Avalonia.Controls;

public class OpenCell : Cell
{ 
	public OpenCell(Cell cell, IFlagCount flagCounter, IMinefield minefield ) : base ( flagCounter, minefield )
    {
        _x = cell.X;
        _y = cell.Y;
        _isFlagged = false;
        _neighbourMines = cell.NeighbourMines;
    }

    public override void LeftClick ( Button button, ISetDeadState igameState )
    {
        return;
    }

    public override void RightClick ( Button button )
    {
        return;
    }
}
