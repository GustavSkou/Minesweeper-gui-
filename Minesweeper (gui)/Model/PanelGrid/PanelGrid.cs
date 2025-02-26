﻿using Avalonia.Controls;
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
        _grid.Name = "PanelGrid";
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

    private Grid CreateGrid ()
    {
        var grid = new Grid ()
        {
            Name = "PanelGrid",
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
            Background = Avalonia.Media.Brushes.Gray,
            RowDefinitions = new Avalonia.Controls.RowDefinitions ("*"),
            ColumnDefinitions = new Avalonia.Controls.ColumnDefinitions ("* * *"),
        };
        

        //for ( int row = 0; row < 1; row++ )
        //{
        //    grid.RowDefinitions.Add ( new RowDefinition () );
        //}

        //for ( int column = 0; column < 3; column++ )
        //{
        //    grid.ColumnDefinitions.Add ( new ColumnDefinition () );
        //}

        return grid;
    }
}