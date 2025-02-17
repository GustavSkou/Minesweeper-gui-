using Avalonia.Controls;
using Avalonia.Media;

public class ClosedCell : Cell
{
    public static IBrush Color = Brushes.Gray;

    public ClosedCell ( int x, int y )
    {
        _x = x;
        _y = y;

        _symbol = " ";

        _isMine = false;
        _isFlagged = false;
        _isRevealed = false;
        _neighbourMines = 0;
    }

    public override void Reveal ( Button button )
    {
        if ( button.Tag is Cell cell )
        {
            if ( cell.IsFlagged ) //maybe _isRevealed is not necessary
            {
                return;
            }
            button.Content = cell.Symbol;
            button.Background = Brushes.LightGray;
            button.Tag = new OpenCell ( cell );
        }
    }
}
