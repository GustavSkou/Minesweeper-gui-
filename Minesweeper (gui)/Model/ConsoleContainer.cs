using Avalonia.Controls;
using Minesweeper__gui_;
using Avalonia.Media.Imaging;
using Avalonia.Media;

public class ConsoleContainer
{
    Grid _grid;

    int _gameContainerHeight, _gameContainerWidth, _panelHeight, _panelWidth;

    public ConsoleContainer( GameWindow window, int gameContainerHeight, int gameContainerWidth, int panelHeight, int panelWidth )
    {
        _grid = GetGrid ( window );
        _gameContainerHeight = gameContainerHeight;
        _gameContainerWidth = gameContainerWidth;
        _panelHeight = panelHeight;
        _panelWidth = panelWidth;

    }

    public void Draw(double height, double width)
    {
        for (int i = 0; i < 2; i++)
        {
            var verticalBorder = CreateVerticalBorder (_gameContainerHeight);
            _grid.Children.Add ( verticalBorder );
            Grid.SetRow ( verticalBorder, 3 );
            Grid.SetColumn ( verticalBorder, i*2 );
        }
        //for ( int i = 0; i < 2; i++ )
        //{
        //    var verticalBorder = CreateVerticalBorder (1);
        //    _grid.Children.Add ( verticalBorder );
        //    Grid.SetRow ( verticalBorder, 1 );
        //    Grid.SetColumn ( verticalBorder, i * 2 );
        //}

        for ( int i = 0; i < 5; i++ )
        {
            var horizontalBorder = CreateHorizontalBorder (_gameContainerWidth);
            _grid.Children.Add ( horizontalBorder );
            Grid.SetRow ( horizontalBorder, i*2 );
            Grid.SetColumn ( horizontalBorder, 1 );
        }



    }

    private StackPanel CreateHorizontalBorder(int width)
    {
        StackPanel stackPanel = new StackPanel()
        {
            Orientation = Avalonia.Layout.Orientation.Horizontal
        };

        for (int i = 0; i < width; i++ )
        {
            stackPanel.Children.Add 
            ( 
                new Image ()
                {
                    Source = new Bitmap( "content\\game_container_image\\horizontal_border (2).png" ),                    
                    Width = 25

                }
            );
        }
        return stackPanel;
    }

    private StackPanel CreateVerticalBorder (int height)
    {
        StackPanel stackPanel = new StackPanel()
        {
            Orientation = Avalonia.Layout.Orientation.Vertical
        };

        for ( int i = 0; i < height; i++ )
        {
            stackPanel.Children.Add
            (
                new Image ()
                {
                    Source = new Bitmap ( "content\\game_container_image\\vertical_border.png" ),
                    Height = 25
                }
            );
        }
        return stackPanel;
    }

    private Grid GetGrid(GameWindow window)
    {
        Grid grid = window.FindControl<Grid>("ConsoleContainer");
        return grid;
    }
}