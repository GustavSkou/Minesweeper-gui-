using Avalonia.Controls;

public class FlagCounter
{
    private int _counter;
    private StackPanel _stackPanel;

    public StackPanel StackPanel { get { return _stackPanel; } }

    public FlagCounter(int mines)
    {
        _stackPanel = CreateStackPanel ();
        _counter = mines;

        SetupCounter (_counter);
    }

    private void SetupCounter(int mines)
    {
        int[] nums = ExtractCountNums();
        UpdateCounter ( nums );
    }

    private void UpdateCounter ( int[] nums)
    {
        _stackPanel.Children.Clear ();
        _stackPanel.Children.Add ( CounterImageHandler.GetImage ( nums[0] ) );
        _stackPanel.Children.Add ( CounterImageHandler.GetImage ( nums[1] ) );
        _stackPanel.Children.Add ( CounterImageHandler.GetImage ( nums[2] ) );
    }

    private int[] ExtractCountNums()
    {
        return [
            _counter / 100,
            ( _counter % 100 ) / 10,
            _counter % 10
        ];
    }

    public void CounterUp()
    {
        _counter++;
    }

    public void CounterDown ()
    {
        _counter--;
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