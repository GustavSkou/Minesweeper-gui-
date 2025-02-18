using Avalonia.Controls;
using Avalonia.Media.Imaging;

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

            var image = new Image
            {
                Source = new Bitmap("content/mine.png"),
                Width = button.Width - 8,
                Height = button.Height - 8
            };

            button.Content = image;
            button.Background = Avalonia.Media.Brushes.Red;
        }
    }

    public override void Flag ( Button button )
    {
        return;
    }
}
