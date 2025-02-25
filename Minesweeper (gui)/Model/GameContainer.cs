
using Avalonia.Controls;
using Minesweeper__gui_;
using System;

class GameContainer
{
    private Grid _grid;

    public Grid Grid
    {
        get { return _grid; }
    }

    public GameContainer ( GameWindow window )
    {
        _grid = GetGrid ( window );
    }

    public void Draw ( GameWindow window )
    {
        PanelGrid panel = new PanelGrid();
        GameState gameState = new GameState(window);
        panel.Add ( gameState.ButtonInstance, 0 );

        var minefieldGrid = Minefield.Instance.CreateMinefieldGrid ( window );

        _grid.Children.Add ( panel.Grid );
        Grid.SetRow ( panel.Grid, 0 );

        _grid.Children.Add ( minefieldGrid );
        Grid.SetRow ( minefieldGrid, 1 );
    }

    private Grid? GetGrid ( GameWindow window )
    {
        var grid =  window.FindControl<Grid> ( "GameContainer" )  ?? throw new InvalidOperationException ( "GameContainer not found in the window." );
        grid.Background = new Avalonia.Media.SolidColorBrush ( Avalonia.Media.Colors.Blue );
        grid.Children.Clear ();

        return grid;
    }
}