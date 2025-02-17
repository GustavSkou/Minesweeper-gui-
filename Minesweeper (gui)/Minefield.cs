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

    private Minefield(int height, int width, int mines)
	{
        _height = height;
        _width = width;
        _mines = mines;

        // Create a 2D array of cells
        // Set the mines
        // Set the number

        cells = new Cell[_height, _width];
        SetCells ( cells );
        SetMines ( cells );
        SetNumbers ( cells );
    }

    public void Draw( MainWindow window )
    {
        var grid = GetGrid ( window );

        for ( int row = 0; row < _height; row++ )
        {
            for ( int column = 0; column < _width; column++ )
            {
                Button button = CreateCellButton ( window, row, column, cells[row, column] );
                
                grid.Children.Add ( button );
                grid.Height = _height * (button.Height + button.Margin.Top + button.Margin.Bottom );
                grid.Width = _width * ( button.Width + button.Margin.Right + button.Margin.Left );

                Grid.SetRow ( button, row );
                Grid.SetColumn ( button, column );
            }
        }
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
        int[ , ] minesCoordinates = new int[ _mines, 2 ];

        int placedMines = 0;
        while (placedMines < 10)
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

    private void SetNumbers ( Cell[,] cells )
    {
        //Go though each cell in cells
        for ( int row = 0; row < _height; row++ )
        {
            for ( int column = 0; column < _width; column++ )
            {
                // Don't count around a mine
                if ( cells[row, column] is Mine) continue;

                // Go through each cell in the 3x3 grid around the cell
                for ( int x = row - 1; x <= row + 1; x++ )
                {
                    for ( int y = column - 1; y <= column + 1; y++ )
                    {
                        // Check if the cell is within the bounds
                        if ( x >= 0 && x < _height && y >= 0 && y < _width )    
                        {
                            // Skip the cell itself
                            if ( x == row && y == column) continue;     
                        
                            if ( cells[x, y] is Mine )
                            {
                                cells[row, column].NeighbourMines++;
                            }
                        }
                    }
                }
                cells[row, column].Symbol = cells[row, column].NeighbourMines > 0 ? 
                    cells[row, column].NeighbourMines.ToString () : 
                    cells[row, column].Symbol;
            }
        }
    }

    private Button CreateCellButton ( MainWindow window, int x, int y, Cell cell)
    {
        Button button = new Button
        {
            Content = " ",
            Width = 35,
            Height = 35,
            Tag = cell,
            Margin = new Avalonia.Thickness ( 5 ),
            Background = ClosedCell.Color
        };

        button.Click += window.CellClickHandler;
        button.PointerReleased += window.CellRightClickHandler;

        return button;
    }

    private Grid? GetGrid ( MainWindow window )
    {
        var grid = window.FindControl<Grid> ( "MinefieldGrid" );

        if ( grid == null )
        {
            throw new InvalidOperationException ( "MinefieldGrid not found in the window." );
        }

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