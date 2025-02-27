using Avalonia.Controls;

public class FlagCounter : IFlagCount , IRestartGame
{
    private int _mines;
    private int _count;
    private StackPanel _stackPanel;

    public int Count { get { return _count; } }
    public StackPanel StackPanel { get { return _stackPanel; } }

    public FlagCounter(GameSettings settings)
    {
        _mines = settings.Mines;
        _count = settings.Mines;
        _stackPanel = CreateStackPanel ();
        
        UpdateCounter ();
    }

    private void UpdateCounter ()
    {
        int[] nums = ExtractCountNums();
        _stackPanel.Children.Clear ();
        _stackPanel.Children.Add ( CounterImageHandler.GetImage ( nums[0] ) );
        _stackPanel.Children.Add ( CounterImageHandler.GetImage ( nums[1] ) );
        _stackPanel.Children.Add ( CounterImageHandler.GetImage ( nums[2] ) );
    }

    private int[] ExtractCountNums()
    {
        return [
            _count / 100,
            ( _count % 100 ) / 10,
            _count % 10
        ];
    }

    public void Up()
    {
        _count++;
        UpdateCounter ();
    }

    public void Down ()
    {
        _count--;
        UpdateCounter ();
    }

    public void RestartGame ()
    {
        _count = _mines;
        UpdateCounter ();
    }

    private StackPanel CreateStackPanel()
    {
        var stackPanel = new StackPanel()
        {
            Orientation = Avalonia.Layout.Orientation.Horizontal,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left,
        };
        return stackPanel;
    }
}