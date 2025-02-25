using Avalonia.Controls;
using Avalonia.Media.Imaging;

public class TimeCounter
{
    private int _counter;
    private StackPanel _stackPanel;

    public StackPanel StackPanel { get { return _stackPanel; } }


    public TimeCounter ()
    {
        _stackPanel = CreateStackPanel ();


        var hundreds = CounterImageHandler.Zero;
        var tens = CounterImageHandler.Zero;
        var ones = CounterImageHandler.Zero;

        _stackPanel.Children.Add ( hundreds );
        _stackPanel.Children.Add ( tens );
        _stackPanel.Children.Add ( ones );

        _counter = 0;
    }


    public void CounterUp ()
    {
        _counter++;
    }

    public void CounterDown ()
    {
        _counter--;
    }

    private StackPanel CreateStackPanel ()
    {
        var stackPanel = new StackPanel()
        {
            Orientation = Avalonia.Layout.Orientation.Horizontal,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right,
        };
        return stackPanel;
    }
}