
using Avalonia.Controls;
using Minesweeper__gui_;
using System;

public class GameContainer
{
    private Grid _grid;
    private PanelGrid _panel;

    private Control _minefield;
    private Control _gameState;
    private Control _flagCounter;
    private Control _timeCounter;

    public GameContainer ( GameWindow window, Control minefield, PanelGrid panel, Control gameState, Control flagCounter, Control timeCounter )
    {
        _grid = GetGrid ( window );

        _minefield = minefield;
        _panel = panel;
        _gameState = gameState;
        _flagCounter = flagCounter;
        _timeCounter = timeCounter;
    }

    public void Draw ( GameWindow window )
    {
        _panel.Add ( _flagCounter, 0 );
        _panel.Add ( _gameState, 1 );
        _panel.Add ( _timeCounter, 2 );


        _grid.Children.Add ( _panel.Grid );
        Grid.SetRow ( _panel.Grid, 0 );

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