using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Minesweeper__gui_;

public class GameStateButton : IClickable , ISetDeadState
{
	private bool _state;
	private static readonly string _contentPath = "content/";
	Image image;			// Current image displayed
	Button buttonInstance;	// Button instance that it is connected to
	GameWindow _window;		// Window 

	/* singleton instance */
	static private GameStateButton _instance = new GameStateButton();
	static public GameStateButton Instance { get { return _instance; } }

	public Button ButtonInstance
	{
		get { return buttonInstance; }
	}

	public GameStateButton (  )
	{
        _state = true;
	}

	private void SetAliveState()
	{
		_state = true;
		SetImage ( _state );
		buttonInstance.Content = image;
	}
	public void SetDeadState ()
	{
		_state = false;
		SetImage ( _state );
		buttonInstance.Content = image;
	}
	
	public void Draw( GameWindow window )
	{
		_window = window;

        var panel = _window.FindControl<StackPanel>("TopPanel");
		panel.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;

		SetImage ( _state );
		SetButton ();

		panel.Children.Add ( buttonInstance );
	}

	public void LeftClick( Button button )
	{
		RestartGame();
	}

    public void RightClick ( Button button)
    {
		return;
    }

    private void RestartGame ()
    {
        Minefield.Instance.ResetMinefield ( _window );
        SetAliveState ();
    }

    private void SetButton()
	{
		buttonInstance = new Button ()
		{
			Content = image,
			Height = Cell.Height,
			Width = Cell.Width,
			Margin = new Avalonia.Thickness ( 0 ),
			Tag = this,
			HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
		};
		buttonInstance.Click += _window.RestartClickHandler;
	}

	private void SetImage ( bool state )
	{
		Bitmap bitmap;
		if ( state )
		{
			bitmap = new Bitmap(_contentPath + "smiley.png");
		}
		else
		{
			bitmap = new Bitmap(_contentPath + "dead_smiley.png");
		}
		image = new Image ()
		{
			Source = bitmap,
			Height = Cell.Height,
			Width = Cell.Width
		};
	}
}