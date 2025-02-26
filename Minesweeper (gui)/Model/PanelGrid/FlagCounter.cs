using Avalonia.Controls;

interface IFlagCount
{
    void Up ();
    void Down ();
}

public class FlagCounter : IFlagCount
{
    private int _counter;
    private StackPanel _stackPanel;

    public StackPanel StackPanel { get { return _stackPanel; } }

    public FlagCounter(int mines)
    {
        _stackPanel = CreateStackPanel ();
        _counter = mines;

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
            _counter / 100,
            ( _counter % 100 ) / 10,
            _counter % 10
        ];
    }

    public void Up()
    {
        _counter++;
        UpdateCounter ();
    }

    public void Down ()
    {
        _counter--;
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