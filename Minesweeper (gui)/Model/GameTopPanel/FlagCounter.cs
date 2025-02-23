using Minesweeper__gui_;

public class FlagCounter
{
    GameWindow _window;
    int _counter;

    public FlagCounter(GameWindow window)
    {
        _counter = 0;
        _window = window;
    }

    public void CounterUp()
    {
        _counter++;
    }

    public void CounterDown ()
    {
        _counter--;
    }
}
