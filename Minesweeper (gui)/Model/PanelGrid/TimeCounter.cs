using Avalonia.Controls;
using Avalonia.Threading;
using System.Timers;

public class TimeCounter : IRestartGame
{
    private int _count;
    private StackPanel _stackPanel;
    private Timer _timer;


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

        _timer = new Timer(1000);
        _timer.Elapsed += OnTimerElapsed;
        _timer.AutoReset = true; // Repeat the timer
        _timer.Enabled = true; // Start the timer
        _count = 0;
    }

    private void OnTimerElapsed ( object sender, ElapsedEventArgs e )
    {

        CounterUp ();
        Dispatcher.UIThread.InvokeAsync ( UpdateCounter );
    }

    public void CounterUp ()
    {
        _count++;
    }

    public void CounterDown ()
    {
        _count--;
    }

    public void RestartGame ()
    {
        _count = 0;
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

    private int[] ExtractCountNums ()
    {
        return [
            _count / 100,
            ( _count % 100 ) / 10,
            _count % 10
        ];
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