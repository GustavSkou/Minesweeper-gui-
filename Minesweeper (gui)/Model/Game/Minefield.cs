using Avalonia.Controls;
using Minesweeper__gui_;
using System;

public class Minefield
{
    private int _height, _width, _mines;
   
    private Cell[,] cells;

    /* Singleton */
    private static Minefield _instance = new Minefield( 9, 9, 10);
    public static Minefield Instance { get { return _instance; } }

    public int Height
    {
        get { return _height; }
    }

    public int Width
    {
        get { return _height; }
    }

    public Cell[,] Cells 
    {
        get { return cells; }
        set { cells = value; }
    }

    private Minefield(int height, int width, int mines)
	{
        _height = height;
        _width = width;
        _mines = mines;

        cells = new Cell[_height, _width];
        SetCells ( cells );
        SetMines ( cells );
        SetNeighborMineNumbers ( cells );
    }

    public void Draw( MainWindow window )
    {
        var grid = GetGrid ( window );

        for ( int row = 0; row < _height; row++ )
        {
            for ( int column = 0; column < _width; column++ )
            {
                Button button = CreateCellButton ( window, cells[row, column] );
                cells[row, column].ButtonInstance = button;     //add button instance to the cell

                grid.Children.Add ( button );
                grid.Height = _height * (button.Height + button.Margin.Top + button.Margin.Bottom );
                grid.Width = _width * ( button.Width + button.Margin.Right + button.Margin.Left );

                Grid.SetRow ( button, row );
                Grid.SetColumn ( button, column );
            }
        }
    }

    public void ResetMinefield ( MainWindow window )
    {
        SetCells ( cells );
        SetMines ( cells );
        SetNeighborMineNumbers ( cells );
        Draw (window);
    }

    private void SetCells( Cell[,] cells)
    {
        for ( int row = 0; row < _height; row++ )
        {
            for ( int column = 0; column < _width; column++ )
            {
                cells[row, column] = new ClosedCell ( row, column );
            }
        }
    }

    private void SetMines ( Cell[,] cells )
    {
        Random random = new Random();

        int placedMines = 0;
        while (placedMines < _mines )
        {
            int row = random.Next ( 0, _height );
            int column = random.Next ( 0, _width );

            if ( cells[row, column] is not Mine )
            {
                placedMines++;
                cells[row, column] = new Mine ( cells[row, column] );
            }            
        }
    }

    private void SetNeighborMineNumbers ( Cell[,] cells )
    {
        //Go though each cell in cells
        for ( int row = 0; row < _height; row++ )
        {
            for ( int column = 0; column < _width; column++ )
            {
                // Don't count around a mine
                if ( cells[row, column] is Mine) 
                    continue;

                // Go through each cell in the 3x3 grid around the cell
                for ( int x = row - 1; x <= row + 1; x++ )
                {
                    for ( int y = column - 1; y <= column + 1; y++ )
                    {
                        // Check if the cell is within the bounds
                        if ( x >= 0 && x < _height && y >= 0 && y < _width )    
                        {
                            // Skip the cell itself
                            if ( x == row && y == column) 
                                continue;     
                        
                            if ( cells[x, y] is Mine )
                            {
                                cells[row, column].NeighbourMines++;
                            }
                        }
                    }
                }
            }
        }
    }

    private Button CreateCellButton ( MainWindow window, Cell cell )
    {
        Button button = new Button
        {
            Content = cell.Image,
            Width = Cell.Width,
            Height = Cell.Height,
            Tag = cell,
            Margin = new Avalonia.Thickness ( 0 ),
            HorizontalContentAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalContentAlignment = Avalonia.Layout.VerticalAlignment.Center,          
        };

        button.Click += window.CellClickHandler;
        button.PointerPressed += ( sender, e ) =>
        {
            if( e.GetCurrentPoint ( button ).Properties.IsLeftButtonPressed )
            {
                window.CellClickHandler ( sender, e );
            }
            else if ( e.GetCurrentPoint ( button ).Properties.IsRightButtonPressed )
            {
                window.CellRightClickHandler ( sender, e );
            }
        };
            
        return button;
    }

    private void Button_PointerReleased ( object? sender, Avalonia.Input.PointerReleasedEventArgs e )
    {
        throw new NotImplementedException ();
    }

    private Grid? GetGrid ( MainWindow window )
    {
        var grid =  window.FindControl<Grid> ( "MinefieldGrid" )  ?? throw new InvalidOperationException ( "MinefieldGrid not found in the window." );
        grid.Children.Clear ();
        grid.RowDefinitions.Clear ();
        grid.ColumnDefinitions.Clear ();

        for ( int i = 0; i < _height; i++ )
        {
            grid.RowDefinitions.Add ( new RowDefinition () );
        }

        for ( int i = 0; i < _width; i++ )
        {
            grid.ColumnDefinitions.Add ( new ColumnDefinition () );
        }

        return grid;
    }
}