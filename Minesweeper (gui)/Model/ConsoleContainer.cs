using Avalonia.Controls;
using Minesweeper__gui_;
using Avalonia.Media.Imaging;
using Avalonia.Media;

public class ConsoleContainer
{
    Grid _grid;

    public ConsoleContainer( GameWindow window )
    {
        _grid = GetGrid ( window );
    }

    public void Draw()
    {
        for (int i = 0; i < 2; i++)
        {
            var verticalBorder = CreateVerticalBorder (9);
            _grid.Children.Add ( verticalBorder );
            Grid.SetRow ( verticalBorder, 3 );
            Grid.SetColumn ( verticalBorder, i*2 );
        }
        for ( int i = 0; i < 2; i++ )
        {
            var verticalBorder = CreateVerticalBorder (1);
            _grid.Children.Add ( verticalBorder );
            Grid.SetRow ( verticalBorder, 1 );
            Grid.SetColumn ( verticalBorder, i * 2 );
        }

        for ( int i = 0; i < 5; i++ )
        {
            var horizontalBorder = CreateHorizontalBorder (9);
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
                    Source = new Bitmap( "content\\game_container_image\\horizontal_border.png" ),                    
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
                    Source = new Bitmap ( "content\\game_container_image\\border.png" ),
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