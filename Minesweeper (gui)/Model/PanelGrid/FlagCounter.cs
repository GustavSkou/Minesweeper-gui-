using Minesweeper__gui_;

public class FlagCounter
{
    GameWindow _window;
    int _counter;

    public FlagCounter()
    {
        _counter = 0;
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