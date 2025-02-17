using Avalonia.Controls;

public class OpenCell : Cell
{



	public OpenCell(Cell cell)
    {
        _x = cell.X;
        _y = cell.Y;

        _symbol = cell.Symbol;

        _isMine = false;
        _isFlagged = false;
        _isRevealed = true;
        _neighbourMines = cell.NeighbourMines;
    }

    public override void Reveal ( Button button )
    {
        return;
    }

    public override void Flag ( Button button )
    {
        return;
    }
}
