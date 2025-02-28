using Avalonia.Controls;
using Minesweeper__gui_;
using System;

public class PanelGrid
{
    private Grid _grid;

    public Grid Grid
    {
        get { return _grid; }
    }

    public PanelGrid (GameWindow window)
    {
        _grid = GetGrid (window);
    }

    public void Draw ()
    {

    }

    public void Add( Control item , int column)
    {
        column = column % 3;

        switch ( column )
        {
            case 0:
            item.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;
            break;
            case 1:
            item.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
            break;
            case 2:
            item.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right;
            break;
        }

        _grid.Children.Add ( item );
        Grid.SetColumn ( item, column );
    }

    private Grid? GetGrid ( GameWindow window )
    {
        var grid = window.FindControl<Grid>("GamePanel") ?? throw new InvalidOperationException("GameContainer not found in the window.");
        return grid;
    }

    //private Grid CreateGrid ()
    //{
    //    var grid = new Grid ()
    //    {
    //        Name = "PanelGrid",
    //        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
    //        Background = Avalonia.Media.Brushes.Gray,
    //        RowDefinitions = new RowDefinitions ("*"),
    //        ColumnDefinitions = new ColumnDefinitions ("* * *"),
    //    };

    //    return grid;
    //}
}