
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
        GameStateButton gameStateButton = new GameStateButton(window);
        GameStateButton gameStateButton2 = new GameStateButton(window);
        GameStateButton gameStateButton3 = new GameStateButton(window);
        panel.Add ( gameStateButton2.ButtonInstance, 1 );
        panel.Add ( gameStateButton.ButtonInstance, 0 );
        panel.Add ( gameStateButton3.ButtonInstance, 2 );

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