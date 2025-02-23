using Avalonia.Controls;
using Avalonia.Media;

public class Mine : Cell
{
    private bool _exploded;

    public bool Exploded
    {
        get { return _exploded; }
    }

    public Mine ( Cell cell )
    {
        Image = cell.Image;
        cell.ButtonInstance = _buttonInstance;

        _exploded = false;
        _x = cell.X;
        _y = cell.Y;

        _isFlagged = cell.IsFlagged;
    }

    public override void LeftClick ( Button button )
    {
        if ( button.Tag is Mine mine )
        {
            if ( mine.IsFlagged || mine.Exploded )
                return;

            mine.Explode ();

            try
            {
                mine.Image = RevealImage ( (Cell) mine );
            }
            catch
            {
                throw new System.Exception ( "Mine exception" );
            }

            button.Content = mine.Image;
        }
    }

    public override void RightClick ( Button button )
    {
        if ( _exploded )
            return;

        base.RightClick ( button );
    }

    private void Explode ()
    {
        _exploded = true;
        //if (game is not over)
            //_buttonInstance.Background = Brushes.Red;

        GameStateButton.Instance.SetDeadState ();
    }
}