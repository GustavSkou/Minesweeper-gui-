
using Avalonia.Controls;
using Minesweeper__gui_;
using System;

public class GameContainer
{
    private Grid _grid;
    private Control _minefield;
    private int _height;
    private int _width;

    public int Height { get { return _height; } }
    public int Width { get { return _width; } }

    public Grid Grid { get { return _grid; } }

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