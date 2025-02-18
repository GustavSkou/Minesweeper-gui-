using Avalonia.Controls;

public class Mine : Cell
{
    public Mine ( Cell cell )
    {
        Image = cell.Image;

        _x = cell.X;
        _y = cell.Y;

        _isFlagged = cell.IsFlagged;
    }

    public override void LeftClick ( Button button )
    {
        if ( button.Tag is Cell cell )
        {
            if ( cell.IsFlagged || cell is OpenCell )
                return;

            try
            {
                button.Content = GetImage ( cell );
            }
            catch
            {
                throw new System.Exception ( "Mine exception" );
            }
        }

        //stop game
    }
}