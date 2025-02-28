
using Avalonia.Controls;
using Minesweeper__gui_;
using System;

public class GameContainer
{
    private Grid _grid;
    private Control _minefield;

    public GameContainer ( GameWindow window, Control minefield)
    {
        _grid = GetGrid ( window );

        _minefield = minefield;
    }

    public void Draw ()
    {
        _grid.Children.Add ( _minefield );
        Grid.SetRow ( _minefield, 1 );
    }

    private Grid? GetGrid ( GameWindow window )
    {
        var grid = window.FindControl<Grid>("GameContainer") ?? throw new InvalidOperationException("GameContainer not found in the window.");
        grid.Children.Clear ();
        return grid;
    }
}