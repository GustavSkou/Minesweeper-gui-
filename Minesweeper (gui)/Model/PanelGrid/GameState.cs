using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Minesweeper__gui_;

public class GameState : IClickable , ISetDeadState, IRestartGame
{
	private bool _state;
	
    private Button _buttonInstance;     // Button instance that it is connected to
    private GameWindow _window;         // Window 
    private IRestartGame _minefield, _flagCounter, _timeCounter;

    public static double Height = Cell.Height * 1.2;
    public static double Width = Cell.Width * 1.2;

	public Button ButtonInstance
	{
		get { return _buttonInstance; }
	}

	public GameState ( GameWindow window, IRestartGame minefield, IRestartGame flagCounter, IRestartGame timeCounter )
	{
        _minefield = minefield;
        _window = window;
        _timeCounter = timeCounter;
        _state = true;
        _flagCounter = flagCounter;
        CreateButton ();
    }

    public void LeftClick( Button button, ISetDeadState state )
	{
		RestartGame();
	}

    public void RightClick ( Button button)
    {
		return;
    }

    private void SetAliveState ()
    {
        _state = true;
        _buttonInstance.Content = GameStateImageHandler.Alive;
    }

    public void SetDeadState ()
    {
        _state = false;
        _buttonInstance.Content = GameStateImageHandler.Dead;
    }

    public void RestartGame ()
    {
        _minefield.RestartGame ();
        _flagCounter.RestartGame ();
        _timeCounter.RestartGame ();
        SetAliveState ();
    }

    private void CreateButton()
	{
		_buttonInstance = new Button ()
		{
			Content = GameStateImageHandler.Alive, 
			Height = Height,
			Width = Height,
			Margin = new Avalonia.Thickness ( 0 ),
			Tag = this,
			HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
			
		};
		_buttonInstance.Click += _window.RestartClickHandler;
	}
}