using Avalonia.Controls;

public class Mine : Cell
{
    public Mine ( Cell cell )
    {
        _x = cell.X;
        _y = cell.Y;

        _symbol = "¤";

        _isMine = true;
        _isFlagged = cell.IsFlagged;
        _isRevealed = cell.IsRevealed;
        _neighbourMines = cell.NeighbourMines;
    }

    public override void Reveal ( Button button )
    {
        if ( button.Tag is Cell cell )
        {
            if ( cell.IsFlagged ) //maybe _isRevealed is not necessary
            {
                return;
            }
            button.Content = _symbol;
            button.Background = Avalonia.Media.Brushes.Red;
        }
    }

    public override void Flag ( Button button )
    {
        return;
    }
}
