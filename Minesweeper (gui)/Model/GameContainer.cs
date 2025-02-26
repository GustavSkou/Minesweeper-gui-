
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
        FlagCounter flagCounter = new FlagCounter(10);

        Minefield minefield = new Minefield(9,9,10, window, flagCounter);
        
        GameState gameState = new GameState(window, minefield, flagCounter);
        PanelGrid panel = new PanelGrid();

        TimeCounter timeCounter = new TimeCounter();

        panel.Add ( gameState.ButtonInstance, 1 );
        panel.Add ( flagCounter.StackPanel, 0 );
        panel.Add ( timeCounter.StackPanel, 2);


        _grid.Children.Add ( panel.Grid );
        Grid.SetRow ( panel.Grid, 0 );

        _grid.Children.Add ( minefield.Grid );
        Grid.SetRow ( minefield.Grid, 1 );
    }

    private Grid? GetGrid ( GameWindow window )
    {
        var grid =  window.FindControl<Grid> ( "GameContainer" )  ?? throw new InvalidOperationException ( "GameContainer not found in the window." );
        grid.Children.Clear ();

        return grid;
    }
}