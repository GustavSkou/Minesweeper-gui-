using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Minesweeper__gui_;

public class GameState : IClickable , ISetDeadState
{
	private bool _state;
	
    private Button _buttonInstance;     // Button instance that it is connected to
    private GameWindow _window;         // Window 

	private static double _height = Cell.Height;
    private static double _width = Cell.Width;

    public double Height { get { return _height; } }
	public double Width { get { return _width; } }

	public Button ButtonInstance
	{
		get { return _buttonInstance; }
	}

	public GameState ( GameWindow window )
	{
        _window = window;
        _state = true;
        CreateButton ();
    }

    public void LeftClick( Button button )
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

    private void RestartGame ()
    {
        Minefield.Instance.ResetMinefield ( _window );
        SetAliveState ();
    }

    private void CreateButton()
	{
		_buttonInstance = new Button ()
		{
			Content = GameStateImageHandler.Alive, 
			Height = _height,
			Width = _width,
			Margin = new Avalonia.Thickness ( 0 ),
			Tag = this,
			HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
			
		};
		_buttonInstance.Click += _window.RestartClickHandler;
	}

	
}