using Avalonia.Controls;
using Minesweeper__gui_;
using System;

public class Minefield : IMinefield, IRestartGame
{
    private int _height, _width, _mines;
    private Cell[,] cells;
    private Grid _grid;
    private IFlagCount _flagCounter;
    private GameWindow _window;

    public int Mines { get { return _mines; } }

    public Grid Grid { get { return _grid; } }
    public int Height { get { return _height; } }
    public int Width { get { return _height; } }

    public Cell[,] Cells 
    {
        get { return cells; }
        set { cells = value; }
    }

    public Minefield(GameSettings settings, GameWindow window, IFlagCount flagCounter)
	{
        _height = settings.Height;
        _width = settings.Width;
        _mines = settings.Mines;
        _flagCounter = flagCounter;
        _window = window;

        cells = new Cell[_height, _width];
        _grid = CreateGrid ();
                
        SetCells ( cells );
        SetMines ( cells );
        SetNeighborMineNumbers ( cells );
        CreateMinefieldGrid ();
    }

    public Grid CreateMinefieldGrid( )
    {
        for ( int row = 0; row < _height; row++ )
        {
            for ( int column = 0; column < _width; column++ )
            {
                Button button = CreateCellButton ( cells[row, column] );
                cells[row, column].ButtonInstance = button;     //add button instance to the cell

                _grid.Children.Add ( button );
                _grid.Height = _height * ( button.Height + button.Margin.Top + button.Margin.Bottom );
                _grid.Width = _width * ( button.Width + button.Margin.Right + button.Margin.Left );

                Grid.SetRow ( button, row );
                Grid.SetColumn ( button, column );
            }
        }
        return _grid;
    }

    public void RestartGame ()
    {
        SetCells ( cells );
        SetMines ( cells );
        SetNeighborMineNumbers ( cells );
        ResetGrid ();
        CreateMinefieldGrid ();
    }

    private void SetCells( Cell[,] cells )
    {
        for ( int row = 0; row < _height; row++ )
        {
            for ( int column = 0; column < _width; column++ )
            {
                cells[row, column] = new ClosedCell ( row, column, _flagCounter, this );
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
                cells[row, column] = new Mine ( cells[row, column], _flagCounter, this );
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

    private Button CreateCellButton ( Cell cell )
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

        button.Click += _window.CellClickHandler;
        button.PointerPressed += ( sender, e ) =>
        {
            if( e.GetCurrentPoint ( button ).Properties.IsLeftButtonPressed )
            {
                _window.CellClickHandler ( sender, e );
            }
            else if ( e.GetCurrentPoint ( button ).Properties.IsRightButtonPressed )
            {
                _window.CellRightClickHandler ( sender, e );
            }
        };
            
        return button;
    }

    private void Button_PointerReleased ( object? sender, Avalonia.Input.PointerReleasedEventArgs e )
    {
        throw new NotImplementedException ();
    }

    private void ResetGrid()
    {
        _grid.Children.Clear ();
    }

    private Grid CreateGrid ()
    {
        Grid grid = new Grid ()
        {
            Name = "MinefieldGrid",
        };

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