
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
        FlagCounter flagCounter = new FlagCounter(Minefield.Instance.Mines);
        TimeCounter timeCounter = new TimeCounter();

        var minefieldGrid = Minefield.Instance.CreateMinefieldGrid ( window );

        panel.Add ( gameState.ButtonInstance, 1 );
        panel.Add ( flagCounter.StackPanel, 0 );
        panel.Add ( timeCounter.StackPanel, 2);


        _grid.Children.Add ( panel.Grid );
        Grid.SetRow ( panel.Grid, 0 );

        _grid.Children.Add ( minefieldGrid );
        Grid.SetRow ( minefieldGrid, 1 );
    }

    private Grid? GetGrid ( GameWindow window )
    {
        var grid =  window.FindControl<Grid> ( "GameContainer" )  ?? throw new InvalidOperationException ( "GameContainer not found in the window." );
        grid.Children.Clear ();

        return grid;
    }
}