using Avalonia.Controls;
using Minesweeper__gui_;
using System;

class PanelGrid
{
    private Grid _grid;

    public Grid Grid
    {
        get { return _grid; }
    }

    public PanelGrid ()
    {
        _grid = CreateGrid ();
        _grid.Background = new Avalonia.Media.SolidColorBrush ( Avalonia.Media.Colors.Red );
        _grid.Name = "PanelGrid";
    }

    public void Add( Control Item , int column)
    {
        column = column % 3;

        _grid.Children.Add ( Item );

        Grid.SetColumn ( Item, column );
    }

    private Grid CreateGrid ()
    {
        var grid = new Grid ();
        grid.Name = "PanelGrid";
        grid.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
        grid.Children.Clear ();
        grid.RowDefinitions.Clear ();
        grid.ColumnDefinitions.Clear ();

        for ( int row = 0; row < 1; row++ )
        {
            grid.RowDefinitions.Add ( new RowDefinition () );
        }

        for ( int column = 0; column < 3; column++ )
        {
            grid.ColumnDefinitions.Add ( new ColumnDefinition () );
        }

        return grid;
    }
}